#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Estudos.MongoDb.Api/Estudos.MongoDb.Api.csproj", "src/Estudos.MongoDb.Api/"]
RUN dotnet restore "src/Estudos.MongoDb.Api/Estudos.MongoDb.Api.csproj"
COPY . .
WORKDIR "/src/src/Estudos.MongoDb.Api"
RUN dotnet build "Estudos.MongoDb.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Estudos.MongoDb.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Estudos.MongoDb.Api.dll"]