FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CMCS.Updater.Migrations/CMCS.Updater.Migrations.csproj", "CMCS.Updater.Migrations/"]
RUN dotnet restore "CMCS.Updater.Migrations/CMCS.Updater.Migrations.csproj"
COPY . .
WORKDIR "/src/CMCS.Updater.Migrations"
RUN dotnet build "CMCS.Updater.Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CMCS.Updater.Migrations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMCS.Updater.Migrations.dll"]
