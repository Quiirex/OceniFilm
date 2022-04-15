FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Identiteta.API/Identiteta.API.csproj", "Identiteta.API/"]
RUN dotnet restore "Identiteta.API/Identiteta.API.csproj"
COPY . .
WORKDIR "/src/Identiteta.API"
RUN dotnet build "Identiteta.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identiteta.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identiteta.API.dll"]