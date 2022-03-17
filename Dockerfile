FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# RUN apt-get update
# RUN apt-get upgrade -y
# RUN apt-get install -y curl
# RUN curl -fsSL https://deb.nodesource.com/setup_16.x | bash -
# RUN apt-get install -y gcc g++ make nodejs
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