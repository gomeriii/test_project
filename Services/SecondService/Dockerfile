#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["SecondService/SecondService.csproj", "SecondService/"]
COPY ["SecondService.Application/SecondService.Application.csproj", "SecondService.Application/"]
COPY ["SecondService.Infrastructure/SecondService.Infrastructure.csproj", "SecondService.Infrastructure/"]
COPY ["SecondService.Domain/SecondService.Domain.csproj", "SecondService.Domain/"]
COPY ["EventBus.Messages/EventBus.Messages.csproj", "EventBus.Messages/"]
RUN dotnet restore "SecondService/SecondService.csproj"
COPY . .
WORKDIR "/src/SecondService"
RUN dotnet build "SecondService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SecondService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecondService.dll"]