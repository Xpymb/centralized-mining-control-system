FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MinerTasks/CMCS.MinerTasks.App/CMCS.MinerTasks.App.csproj", "CMCS.MinerTasks.App/"]
RUN dotnet restore "MinerTasks/CMCS.MinerTasks.App/CMCS.MinerTasks.App.csproj"
COPY . .
WORKDIR "/src/CMCS.MinerTasks.App"
RUN dotnet build "CMCS.MinerTasks.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CMCS.MinerTasks.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMCS.MinerTasks.App.dll"]
