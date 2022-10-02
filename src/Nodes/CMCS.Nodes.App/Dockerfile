FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Nodes/CMCS.Nodes.App/CMCS.Nodes.App.csproj", "CMCS.Nodes.App/"]
RUN dotnet restore "Nodes/CMCS.Nodes.App/CMCS.Nodes.App.csproj"
COPY . .
WORKDIR "/src/CMCS.Nodes.App"
RUN dotnet build "CMCS.Nodes.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CMCS.Nodes.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMCS.Nodes.App.dll"]
