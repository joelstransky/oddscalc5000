#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY OddsCalc5000/OddsCalc5000.csproj OddsCalc5000/
RUN dotnet restore "OddsCalc5000/OddsCalc5000.csproj"
COPY . .
WORKDIR "/src/OddsCalc5000"
RUN dotnet build "OddsCalc5000.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OddsCalc5000.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OddsCalc5000.dll"]
