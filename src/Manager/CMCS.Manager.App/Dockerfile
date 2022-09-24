FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Manager/CMCS.Manager.App/CMCS.Manager.App.csproj", "CMCS.Manager.App/"]
RUN dotnet restore "Manager/CMCS.Manager.App/CMCS.Manager.App.csproj"
COPY . .
WORKDIR "/src/CMCS.Manager.App"
RUN dotnet build "CMCS.Manager.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CMCS.Manager.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMCS.Manager.App.dll"]
