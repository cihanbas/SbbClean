FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY *.slnx ./
COPY SBBClean.Domain/*.csproj SBBClean.Domain/
COPY SBBClean.Application/*.csproj SBBClean.Application/
COPY SBBClean.Infrastructure/*.csproj SBBClean.Infrastructure/
COPY SBBClean.API/*.csproj SBBClean.API/

RUN dotnet restore SBBClean.slnx

COPY . .
RUN dotnet publish SBBClean.API/SBBClean.API.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:10.0
RUN apt-get update && apt-get install -y libgssapi-krb5-2 && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "SBBClean.API.dll"]
