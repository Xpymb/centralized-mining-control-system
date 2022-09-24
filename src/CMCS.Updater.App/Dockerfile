FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CMCS.Updater.App/CMCS.Updater.App.csproj", "CMCS.Updater.App/"]
RUN dotnet restore "CMCS.Updater.App/CMCS.Updater.App.csproj"
COPY . .
WORKDIR "/src/CMCS.Updater.App"
RUN dotnet build "CMCS.Updater.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CMCS.Updater.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMCS.Updater.App.dll"]
