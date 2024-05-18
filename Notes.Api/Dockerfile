FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Notes.Api/Notes.Api.csproj", "Notes.Api/"]
COPY ["Notes.Application/Notes.Application.csproj", "Notes.Application/"]
COPY ["Notes.Infrastructure/Notes.Infrastructure.csproj", "Notes.Infrastructure/"]
COPY ["Notes.Domain/Notes.Domain.csproj", "Notes.Domain/"]
RUN dotnet restore "./Notes.Api/./Notes.Api.csproj"
COPY . .
WORKDIR "/src/Notes.Api"
RUN dotnet build "./Notes.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Notes.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notes.Api.dll"]