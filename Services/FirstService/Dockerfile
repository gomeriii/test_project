#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["FirstService/FirstService.csproj", "FirstService/"]
COPY ["FirstService.Application/FirstService.Application.csproj", "FirstService.Application/"]
COPY ["EventBus.Messages/EventBus.Messages.csproj", "EventBus.Messages/"]
RUN dotnet restore "FirstService/FirstService.csproj"
COPY . .
WORKDIR "/src/FirstService"
RUN dotnet build "FirstService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FirstService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FirstService.dll"]