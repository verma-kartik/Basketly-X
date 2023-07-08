FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Courier/Courier.API/Courier.API.csproj", "Courier.API/"]
RUN dotnet restore "Services/Courier/Courier.API/Courier.API.csproj"
COPY . .
WORKDIR "/src/Courier.API"
RUN dotnet build "Courier.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Courier.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Courier.API.dll"]
