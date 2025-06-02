FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["CleanArchTemplate.Api/CleanArchTemplate.Api.csproj", "CleanArchTemplate.Api/"]
RUN dotnet restore "CleanArchTemplate.Api/CleanArchTemplate.Api.csproj"
COPY . .
WORKDIR "/src/CleanArchTemplate.Api"
RUN dotnet build "CleanArchTemplate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchTemplate.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchTemplate.Api.dll"]
