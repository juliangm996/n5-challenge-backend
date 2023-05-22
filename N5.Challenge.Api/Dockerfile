#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["N5.Challenge.Api/N5.Challenge.Api.csproj", "N5.Challenge.Api/"]
RUN dotnet restore "N5.Challenge.Api/N5.Challenge.Api.csproj"
COPY . .
WORKDIR "/src/N5.Challenge.Api"
RUN dotnet build "N5.Challenge.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "N5.Challenge.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N5.Challenge.Api.dll"]