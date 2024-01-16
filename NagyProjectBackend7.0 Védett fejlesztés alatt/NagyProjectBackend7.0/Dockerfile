#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NagyProjectBackend7.0/NagyProjectBackend7.0.csproj", "NagyProjectBackend7.0/"]
RUN dotnet restore "NagyProjectBackend7.0/NagyProjectBackend7.0.csproj"
COPY . .
WORKDIR "/src/NagyProjectBackend7.0"
RUN dotnet build "NagyProjectBackend7.0.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NagyProjectBackend7.0.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NagyProjectBackend7.0.dll"]