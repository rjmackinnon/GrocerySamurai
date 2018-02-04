FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY MagicHamster.GrocerySamurai.ServiceLayer/MagicHamster.GrocerySamurai.ServiceLayer.csproj MagicHamster.GrocerySamurai.ServiceLayer/
COPY MagicHamster.GrocerySamurai.DataAccess/MagicHamster.GrocerySamurai.DataAccess.csproj MagicHamster.GrocerySamurai.DataAccess/
COPY MagicHamster.GrocerySamurai.Model/MagicHamster.GrocerySamurai.Model.csproj MagicHamster.GrocerySamurai.Model/
COPY MagicHamster.GrocerySamurai.BusinessLayer/MagicHamster.GrocerySamurai.BusinessLayer.csproj MagicHamster.GrocerySamurai.BusinessLayer/
RUN dotnet restore
COPY . .
WORKDIR /src/MagicHamster.GrocerySamurai.ServiceLayer
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MagicHamster.GrocerySamurai.ServiceLayer.dll"]
