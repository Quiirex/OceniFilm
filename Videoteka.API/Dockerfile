#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Videoteka.API/Videoteka.API.csproj", "Videoteka.API/"]
RUN dotnet restore "Videoteka.API/Videoteka.API.csproj"
COPY . .
WORKDIR "/src/Videoteka.API"
RUN dotnet build "Videoteka.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Videoteka.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Videoteka.API.dll"]