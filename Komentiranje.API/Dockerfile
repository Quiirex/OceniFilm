FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Komentiranje.API/Komentiranje.API.csproj", "Komentiranje.API/"]
RUN dotnet restore "Komentiranje.API/Komentiranje.API.csproj"
COPY . .
WORKDIR "/src/Komentiranje.API"
RUN dotnet build "Komentiranje.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Komentiranje.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Komentiranje.API.dll"]