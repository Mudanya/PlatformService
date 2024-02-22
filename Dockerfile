FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /src
COPY './PlatformService.csproj' .
RUN dotnet restore './PlatformService.csproj'
COPY . .
RUN dotnet build './PlatformService.csproj' -c Release -o /app/build

FROM build as publish
RUN dotnet publish './PlatformService.csproj' -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "PlatformService.dll" ]