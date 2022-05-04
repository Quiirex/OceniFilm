FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OceniFilm/OceniFilm.csproj", "OceniFilm/"]
RUN dotnet restore "OceniFilm/OceniFilm.csproj"
COPY . .
WORKDIR "/src/OceniFilm"
RUN dotnet build "OceniFilm.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OceniFilm.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OceniFilm.dll"]