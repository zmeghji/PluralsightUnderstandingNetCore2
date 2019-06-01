FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["NetCore2WebApp/NetCore2WebApp.csproj", "NetCore2WebApp/"]
RUN dotnet restore "NetCore2WebApp/NetCore2WebApp.csproj"
COPY . .
WORKDIR "/src/NetCore2WebApp"
RUN dotnet build "NetCore2WebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NetCore2WebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetCore2WebApp.dll"]