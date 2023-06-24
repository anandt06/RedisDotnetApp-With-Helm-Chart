#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# comment if env is not dev
ENV ASPNETCORE_DEVELOPMENT=Development 
WORKDIR /app

COPY . ./

RUN dotnet restore "DockerDemo.csproj"

RUN dotnet publish "DockerDemo.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app


EXPOSE 5002

COPY --from=build /app/out/ ./
ENV ASPNETCORE_URLS=http://*:5002
ENTRYPOINT ["dotnet", "DockerDemo.dll", "environment=Development"]
#ENTRYPOINT ["dotnet", "ReceiverEDCAdapter.dll"]

ENV DB_SERVER edc-adapter-db