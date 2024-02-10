FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BookShop.Api/BookShop.Api.csproj", "BookShop.Api/"]
RUN dotnet restore "BookShop.Api/BookShop.Api.csproj"
COPY . .
WORKDIR "/src/BookShop.Api"
RUN dotnet build "BookShop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookShop.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookShop.Api.dll"]
