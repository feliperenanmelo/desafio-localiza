FROM mcr.microsoft.com/dotnet/nightly/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["./Localiza.Veiculos.Api/Localiza.Veiculos.Api.csproj", "api/Localiza.Veiculos.Api/"]
RUN dotnet restore "api/Localiza.Veiculos.Api/Localiza.Veiculos.Api.csproj"
COPY . .
WORKDIR "Localiza.Veiculos.Api/"
RUN dotnet build "Localiza.Veiculos.Api.csproj" -c Release -o /app/build

FROM build AS publish
Run dotnet publish "Localiza.Veiculos.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","Localiza.Veiculos.Api.dll"]

