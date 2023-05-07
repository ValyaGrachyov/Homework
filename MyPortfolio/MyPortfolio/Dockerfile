FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyPortfolio/MyPortfolio.csproj", "MyPortfolio/"]
RUN dotnet restore "MyPortfolio/MyPortfolio.csproj"
COPY . .
WORKDIR "/src/MyPortfolio"
RUN dotnet build "MyPortfolio.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyPortfolio.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyPortfolio.dll"]
