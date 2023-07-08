FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Pricing/Pricing.API/Pricing.API.csproj", "Pricing.API/"]
RUN dotnet restore "Services/Pricing/Pricing.API/Pricing.API.csproj"
COPY . .
WORKDIR "/src/Pricing.API"
RUN dotnet build "Pricing.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pricing.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pricing.API.dll"]
