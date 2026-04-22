# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["src/OperationsManagement.WebAPI/OperationsManagement.WebAPI.csproj", "src/OperationsManagement.WebAPI/"]
COPY ["src/OperationsManagement.Application/OperationsManagement.Application.csproj", "src/OperationsManagement.Application/"]
COPY ["src/OperationsManagement.Contracts/OperationsManagement.Contracts.csproj", "src/OperationsManagement.Contracts/"]
COPY ["src/OperationsManagement.SharedKernel/OperationsManagement.SharedKernel.csproj", "src/OperationsManagement.SharedKernel/"]
COPY ["src/OperationsManagement.Domain/OperationsManagement.Domain.csproj", "src/OperationsManagement.Domain/"]
COPY ["src/OperationsManagement.Infrastructure/OperationsManagement.Infrastructure.csproj", "src/OperationsManagement.Infrastructure/"]
COPY ["src/OperationsManagement.WebAPI.Contracts/OperationsManagement.WebAPI.Contracts.csproj", "src/OperationsManagement.WebAPI.Contracts/"]
RUN dotnet restore "./src/OperationsManagement.WebAPI/OperationsManagement.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/OperationsManagement.WebAPI"
RUN dotnet build "./OperationsManagement.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OperationsManagement.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OperationsManagement.WebAPI.dll"]