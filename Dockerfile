FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TodoMinimalAPI/TodoMinimalAPI.csproj", "TodoMinimalAPI/"]
RUN dotnet restore "TodoMinimalAPI/TodoMinimalAPI.csproj"
COPY . .
WORKDIR "/src/TodoMinimalAPI"
RUN dotnet build "TodoMinimalAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoMinimalAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoMinimalAPI.dll"]
