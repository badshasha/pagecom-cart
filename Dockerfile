FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
#EXPOSE 5300
#
#ENV ASPNETCORE_URLS=http://+:5300

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["pagecom.test/pagecom.test.csproj", "pagecom.test/"]
COPY ["pagecom.cart.app/pagecom.cart.app.csproj", "pagecom.cart.app/"]
COPY ["pagecom.cart.domain/pagecom.cart.domain.csproj", "pagecom.cart.domain/"]
COPY ["pagecom.common/pagecom.common.csproj", "pagecom.common/"]
COPY ["pagecom.cart.data/pagecom.cart.data.csproj", "pagecom.cart.data/"]
COPY ["pagecom.infastructure/pagecom.infastructure.csproj", "pagecom.infastructure/"]

RUN dotnet restore "pagecom.test/pagecom.test.csproj"
COPY . .
WORKDIR "/src/pagecom.test"
RUN dotnet build "pagecom.test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "pagecom.test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "pagecom.test.dll"]
