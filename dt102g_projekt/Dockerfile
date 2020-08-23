#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["dt102g_projekt/dt102g_projekt.csproj", "dt102g_projekt/"]
RUN dotnet restore "dt102g_projekt/dt102g_projekt.csproj"
COPY . .
WORKDIR "/src/dt102g_projekt"
RUN dotnet build "dt102g_projekt.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dt102g_projekt.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dt102g_projekt.dll"]