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

namespace UniversityHelper.FeedbackService;

public class Startup : BaseApiInfo
{
  public const string CorsPolicyName = "LtDoCorsPolicy";

  private readonly RabbitMqConfig _rabbitMqConfig;
  private readonly BaseServiceInfoConfig _serviceInfoConfig;

  private IConfiguration Configuration { get; }

  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;

    _rabbitMqConfig = Configuration
      .GetSection(BaseRabbitMqConfig.SectionName)
      .Get<RabbitMqConfig>();

    _serviceInfoConfig = Configuration
      .GetSection(BaseServiceInfoConfig.SectionName)
      .Get<BaseServiceInfoConfig>();

    Version = "2.0.1.0";
    Description = "FeedbackService is an API that intended to work with feedback.";
    StartTime = DateTime.UtcNow;
    ApiName = $"UniversityHelper - {_serviceInfoConfig.Name}";
  }

  #region public methods

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddCors(options =>
    {
      options.AddPolicy(
        CorsPolicyName,
        builder =>
        {
          builder
            .AllowAnyOrigin()
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

    string connStr = ConnectionStringHandler.Get(Configuration);

    services.AddDbContext<FeedbackServiceDbContext>(options =>
    {
      options.UseSqlServer(connStr);
    });

    services.AddHealthChecks()
      .AddSqlServer(connStr)
      .AddRabbitMqCheck();

    services.AddBusinessObjects();

    ConfigureMassTransit(services);
  }

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
  }

  #endregion

  #region private methods

  private void ConfigureMassTransit(IServiceCollection services)
  {
    (string username, string password) = RabbitMqCredentialsHelper
      .Get(_rabbitMqConfig, _serviceInfoConfig);
    services.AddMassTransit(x =>
    {
      x.UsingRabbitMq((_, cfg) =>
      {
        cfg.Host(_rabbitMqConfig.Host, "/", host =>
        {
          host.Username(username);
          host.Password(password);
        });
      });

      x.AddRequestClients(_rabbitMqConfig);
    });

    services.AddMassTransitHostedService();
  }

  #endregion
}
