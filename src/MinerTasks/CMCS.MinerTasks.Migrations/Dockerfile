FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MinerTasks/CMCS.MinerTasks.Migrations/CMCS.MinerTasks.Migrations.csproj", "CMCS.MinerTasks.Migrations/"]
RUN dotnet restore "MinerTasks/CMCS.MinerTasks.Migrations/CMCS.MinerTasks.Migrations.csproj"
COPY . .
WORKDIR "/src/CMCS.MinerTasks.Migrations"
RUN dotnet build "CMCS.MinerTasks.Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CMCS.MinerTasks.Migrations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMCS.MinerTasks.Migrations.dll"]
