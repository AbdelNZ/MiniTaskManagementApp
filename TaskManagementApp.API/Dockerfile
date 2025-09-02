FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["TaskManagementApp.API/TaskManagementApp.API.csproj", "TaskManagementApp.API/"]
COPY ["TaskManagementApp.Application/TaskManagementApp.Application.csproj", "TaskManagementApp.Application/"]
COPY ["TaskManagementApp.Domain/TaskManagementApp.Domain.csproj", "TaskManagementApp.Domain/"]
COPY ["TaskManagementApp.Infrastructure/TaskManagementApp.Infrastructure.csproj", "TaskManagementApp.Infrastructure/"]
RUN dotnet restore "TaskManagementApp.API/TaskManagementApp.API.csproj"
COPY . .
WORKDIR "/src/TaskManagementApp.API"
RUN dotnet build "TaskManagementApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskManagementApp.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagementApp.API.dll"]
