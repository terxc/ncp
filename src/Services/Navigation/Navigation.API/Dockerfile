#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Navigation/Navigation.API/Navigation.API.csproj", "Services/Navigation/Navigation.API/"]
RUN dotnet restore "Services/Navigation/Navigation.API/Navigation.API.csproj"
COPY . .
WORKDIR "/src/Services/Navigation/Navigation.API"
RUN dotnet build "Navigation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Navigation.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Navigation.API.dll"]
