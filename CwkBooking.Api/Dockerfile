FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CwkBooking.Api/CwkBooking.Api.csproj", "CwkBooking.Api/"]
RUN dotnet restore "CwkBooking.Api/CwkBooking.Api.csproj"
COPY . .
WORKDIR "/src/CwkBooking.Api"
RUN dotnet build "CwkBooking.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CwkBooking.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CwkBooking.Api.dll"]
