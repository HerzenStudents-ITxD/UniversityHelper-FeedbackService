# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy solution and project files
COPY . ./

# Restore dependencies
RUN dotnet restore src/FeedbackService/FeedbackService.csproj --no-cache --source https://api.nuget.org/v3/index.json

# Copy the rest of the source code
COPY . ./

# Trust development certificates
RUN dotnet dev-certs https --trust

# Publish the application
RUN dotnet publish src/FeedbackService/FeedbackService.csproj -c Release -o out

# Stage 2: Create runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
COPY --from=build /app/out .
COPY --from=build /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/

ENTRYPOINT ["dotnet", "UniversityHelper.FeedbackService.dll"]