FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .
RUN dotnet publish MiniHittegods.Api/MiniHittegods.Api.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /out .
ENTRYPOINT ["dotnet", "MiniHittegods.Api.dll"]