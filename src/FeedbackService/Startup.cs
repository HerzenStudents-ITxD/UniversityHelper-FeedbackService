using HealthChecks.UI.Client;
using UniversityHelper.FeedbackService.Data.Provider.MsSql.Ef;
using UniversityHelper.FeedbackService.Models.Dto.Configurations;
using UniversityHelper.Core.BrokerSupport.Configurations;
using UniversityHelper.Core.BrokerSupport.Extensions;
using UniversityHelper.Core.BrokerSupport.Helpers;
using UniversityHelper.Core.BrokerSupport.Middlewares.Token;
using UniversityHelper.Core.Configurations;
using UniversityHelper.Core.EFSupport.Extensions;
using UniversityHelper.Core.EFSupport.Helpers;
using UniversityHelper.Core.Extensions;
using UniversityHelper.Core.Middlewares.ApiInformation;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;

namespace UniversityHelper.FeedbackService
{
  /// <summary>
  /// Configures the FeedbackService application services and middleware.
  /// </summary>
  public class Startup : BaseApiInfo
  {
    public const string CorsPolicyName = "FeedbackServiceCorsPolicy";

    private readonly RabbitMqConfig _rabbitMqConfig;
    private readonly BaseServiceInfoConfig _serviceInfoConfig;
    private readonly IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

      _rabbitMqConfig = Configuration
          .GetSection(BaseRabbitMqConfig.SectionName)
          .Get<RabbitMqConfig>() ?? throw new InvalidOperationException("RabbitMQ configuration is missing.");

      _serviceInfoConfig = Configuration
          .GetSection(BaseServiceInfoConfig.SectionName)
          .Get<BaseServiceInfoConfig>() ?? throw new InvalidOperationException("Service info configuration is missing.");

      Version = "2.0.2.0";
      Description = "FeedbackService is an API that intended to work with feedback.";
      StartTime = DateTime.UtcNow;
      ApiName = $"UniversityHelper - {_serviceInfoConfig.Name}";
    }

    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy(
            CorsPolicyName,
            builder =>
            {
              builder
                          .WithOrigins(Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? new[] { "http://localhost:3000" })
                          .AllowAnyHeader()
                          .AllowAnyMethod();
            });
      });

      services.Configure<TokenConfiguration>(Configuration.GetSection("CheckTokenMiddleware"));
      services.Configure<BaseRabbitMqConfig>(Configuration.GetSection(BaseRabbitMqConfig.SectionName));
      services.Configure<BaseServiceInfoConfig>(Configuration.GetSection(BaseServiceInfoConfig.SectionName));

      services.AddHttpContextAccessor();
      services
          .AddControllers()
          .AddJsonOptions(options =>
          {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
          })
          .AddNewtonsoftJson();

      string connStr = ConnectionStringHandler.Get(Configuration) ?? throw new InvalidOperationException("Database connection string is missing.");
      services.AddDbContext<FeedbackServiceDbContext>(options =>
      {
        options.UseSqlServer(connStr);
      });

      services.AddHealthChecks()
          .AddSqlServer(connStr)
          .AddRabbitMqCheck();

      services.AddBusinessObjects();
      services.ConfigureMassTransit(_rabbitMqConfig);

      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc($"{Version}", new OpenApiInfo
        {
          Version = Version,
          Title = _serviceInfoConfig.Name,
          Description = Description
        });
        options.EnableAnnotations();
      });
    }

    /// <summary>
    /// Configures the application middleware pipeline.
    /// </summary>
    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
      app.UpdateDatabase<FeedbackServiceDbContext>();
      app.UseForwardedHeaders();
      app.UseExceptionsHandler(loggerFactory);
      app.UseApiInformation();
      app.UseRouting();
      app.UseMiddleware<TokenMiddleware>();
      app.UseCors(CorsPolicyName);

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers().RequireCors(CorsPolicyName);
        endpoints.MapHealthChecks($"/{_serviceInfoConfig.Id}/hc", new HealthCheckOptions
        {
          ResultStatusCodes = new Dictionary<HealthStatus, int>
                    {
                        { HealthStatus.Unhealthy, 200 },
                        { HealthStatus.Healthy, 200 },
                        { HealthStatus.Degraded, 200 },
                    },
          Predicate = check => check.Name != "masstransit-bus",
          ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
      });

      app.UseSwagger()
          .UseSwaggerUI(options =>
          {
            options.SwaggerEndpoint($"/swagger/{Version}/swagger.json", $"{Version}");
          });
    }
  }
}