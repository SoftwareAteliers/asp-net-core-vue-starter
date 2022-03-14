FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./AspNetCoreVueStarter.csproj", "app/"]
RUN dotnet restore "app/AspNetCoreVueStarter.csproj"
COPY . .
RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install -y nodejs
RUN dotnet build "/src/AspNetCoreVueStarter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/AspNetCoreVueStarter.csproj" -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNetCoreVueStarter.dll"]
