FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["INET410-Linq-CharacterStats.csproj", "./"]
RUN dotnet restore "INET410-Linq-CharacterStats.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "INET410-Linq-CharacterStats.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "INET410-Linq-CharacterStats.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "INET410-Linq-CharacterStats.dll"]
