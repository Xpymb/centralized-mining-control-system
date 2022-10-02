FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Coins/CMCS.Coins.Migrations/CMCS.Coins.Migrations.csproj", "CMCS.Coins.Migrations/"]
RUN dotnet restore "Coins/CMCS.Coins.Migrations/CMCS.Coins.Migrations.csproj"
COPY . .
WORKDIR "/src/CMCS.Coins.Migrations"
RUN dotnet build "CMCS.Coins.Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CMCS.Coins.Migrations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMCS.Coins.Migrations.dll"]
