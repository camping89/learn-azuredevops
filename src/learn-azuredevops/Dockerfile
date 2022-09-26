FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["learn-azuredevops/learn-azuredevops.csproj", "learn-azuredevops/"]
RUN dotnet restore "learn-azuredevops/learn-azuredevops.csproj"
COPY . .
WORKDIR "/src/learn-azuredevops"
RUN dotnet build "learn-azuredevops.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "learn-azuredevops.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "learn-azuredevops.dll"]
