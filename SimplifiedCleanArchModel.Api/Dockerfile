FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SimplifiedCleanArchModel.Api/SimplifiedCleanArchModel.Api.csproj", "SimplifiedCleanArchModel.Api/"]
RUN dotnet restore "SimplifiedCleanArchModel.Api/SimplifiedCleanArchModel.Api.csproj"
COPY . .
WORKDIR "/src/SimplifiedCleanArchModel.Api"
RUN dotnet build "SimplifiedCleanArchModel.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimplifiedCleanArchModel.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimplifiedCleanArchModel.Api.dll"]
