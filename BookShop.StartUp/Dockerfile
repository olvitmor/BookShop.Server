FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BookShop.StartUp/BookShop.StartUp.csproj", "BookShop.StartUp/"]
RUN dotnet restore "BookShop.StartUp/BookShop.StartUp.csproj"
COPY . .
WORKDIR "/src/BookShop.StartUp"
RUN dotnet build "BookShop.StartUp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookShop.StartUp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookShop.StartUp.dll"]
