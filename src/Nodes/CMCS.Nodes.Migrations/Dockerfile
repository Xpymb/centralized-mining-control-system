FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Nodes/CMCS.Nodes.Migrations/CMCS.Nodes.Migrations.csproj", "CMCS.Nodes.Migrations/"]
RUN dotnet restore "Nodes/CMCS.Nodes.Migrations/CMCS.Nodes.Migrations.csproj"
COPY . .
WORKDIR "/src/CMCS.Nodes.Migrations"
RUN dotnet build "CMCS.Nodes.Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CMCS.Nodes.Migrations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMCS.Nodes.Migrations.dll"]
