FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Seznami.API/Seznami.API.csproj", "Seznami.API/"]
RUN dotnet restore "Seznami.API/Seznami.API.csproj"
COPY . .
WORKDIR "/src/Seznami.API"
RUN dotnet build "Seznami.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Seznami.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Seznami.API.dll"]