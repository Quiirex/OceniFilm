#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ocenjevanje.API/Ocenjevanje.API.csproj", "Ocenjevanje.API/"]
RUN dotnet restore "Ocenjevanje.API/Ocenjevanje.API.csproj"
COPY . .
WORKDIR "/src/Ocenjevanje.API"
RUN dotnet build "Ocenjevanje.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ocenjevanje.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ocenjevanje.API.dll"]