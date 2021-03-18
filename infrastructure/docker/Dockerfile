FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0.201-buster-slim-amd64 AS build
RUN curl --silent --location https://deb.nodesource.com/setup_15.x | bash -
RUN apt-get install --yes nodejs
WORKDIR src/
COPY . .
RUN dotnet publish hello.net.csproj -c Release -o /app

FROM base as run
COPY --from=build /app .

ENTRYPOINT ["dotnet", "hello.net.dll"]


