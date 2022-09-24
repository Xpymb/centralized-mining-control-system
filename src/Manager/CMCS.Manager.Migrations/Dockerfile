FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Manager/CMCS.Manager.Migrations/CMCS.Manager.Migrations.csproj", "CMCS.Manager.Migrations/"]
RUN dotnet restore "Manager/CMCS.Manager.Migrations/CMCS.Manager.Migrations.csproj"
COPY . .
WORKDIR "/src/CMCS.Manager.Migrations"
RUN dotnet build "CMCS.Manager.Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CMCS.Manager.Migrations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMCS.Manager.Migrations.dll"]
