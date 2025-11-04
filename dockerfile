# ===== build =====
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copia solo il csproj per sfruttare la cache del restore
COPY *.csproj ./
RUN dotnet restore

# copia tutto e pubblica
COPY . .
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# ===== runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# ascolta su 8080 nel container
ENV ASPNETCORE_HTTP_PORTS=8080
ENV ASPNETCORE_ENVIRONMENT=Development

COPY --from=build /app/publish ./
EXPOSE 8080
ENTRYPOINT ["dotnet", "ODataDemo.dll"]
