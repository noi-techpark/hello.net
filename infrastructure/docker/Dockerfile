FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0.102-alpine3.12-amd64 AS build
WORKDIR src/
COPY . .
RUN dotnet publish hello.net.csproj -c Release -o /app

FROM base as run
COPY --from=build /app .

ENTRYPOINT ["dotnet", "hello.net.dll"]


