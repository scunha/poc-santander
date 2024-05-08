#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine as build
WORKDIR /src
COPY nuget.config ./
COPY ["nuget.config", "."]
COPY ["Juntos.SomosMais.Challenge.API/Juntos.SomosMais.Challenge.API.csproj", "Juntos.SomosMais.Challenge.API/"]
COPY ["Juntos.SomosMais.Challenge.Domain/Juntos.SomosMais.Challenge.Domain.csproj", "Juntos.SomosMais.Challenge.Domain/"]
COPY ["Juntos.SomosMais.Challenge.Infra/Juntos.SomosMais.Challenge.Infra.csproj", "Juntos.SomosMais.Challenge.Infra/"]
COPY ["Juntos.SomosMais.Challenge.Service/Juntos.SomosMais.Challenge.Service.csproj", "Juntos.SomosMais.Challenge.Service/"]
RUN dotnet restore -s https://api.nuget.org/v3/index.json "Juntos.SomosMais.Challenge.API/Juntos.SomosMais.Challenge.API.csproj"
COPY . .
WORKDIR "/src/Juntos.SomosMais.Challenge.API"
RUN dotnet build "Juntos.SomosMais.Challenge.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Juntos.SomosMais.Challenge.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Juntos.SomosMais.Challenge.API.dll"]