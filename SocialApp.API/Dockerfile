FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SocialApp.API/SocialApp.API.csproj", "SocialApp.API/"]
RUN dotnet restore "SocialApp.API/SocialApp.API.csproj"
COPY . .
WORKDIR "/src/SocialApp.API"
RUN dotnet build "SocialApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SocialApp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SocialApp.API.dll"]
