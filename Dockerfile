FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ColoursWeb.csproj", "."]
RUN dotnet restore "./ColoursWeb.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ColoursWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ColoursWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ColoursWeb.dll"]