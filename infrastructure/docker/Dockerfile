FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0.201-buster-slim-amd64 AS build
RUN curl --silent --location https://deb.nodesource.com/setup_15.x | bash -
RUN apt-get install --yes nodejs
WORKDIR src/
COPY . .
RUN cd webapp && dotnet publish hello.net.csproj -c Release -o /app

FROM base as run
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "hello.net.dll"]
