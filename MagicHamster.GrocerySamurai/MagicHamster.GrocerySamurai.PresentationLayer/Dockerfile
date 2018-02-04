FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY MagicHamster.GrocerySamurai.PresentationLayer/MagicHamster.GrocerySamurai.PresentationLayer.csproj MagicHamster.GrocerySamurai.PresentationLayer/
COPY MagicHamster.GrocerySamurai.NavigationHelper/MagicHamster.GrocerySamurai.NavigationHelper.csproj MagicHamster.GrocerySamurai.NavigationHelper/
COPY MagicHamster.GrocerySamurai.Model/MagicHamster.GrocerySamurai.Model.csproj MagicHamster.GrocerySamurai.Model/
RUN dotnet restore
COPY . .
WORKDIR /src/MagicHamster.GrocerySamurai.PresentationLayer
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MagicHamster.GrocerySamurai.PresentationLayer.dll"]
