# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln .
COPY MyApp.*/*.csproj ./
RUN for file in *.csproj; do mkdir -p ${file%%.*} && mv $file ${file%%.*}/; done

COPY . .
RUN dotnet restore
RUN dotnet publish MyApp.Api/MyApp.Api.csproj -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "MyApp.Api.dll"]
