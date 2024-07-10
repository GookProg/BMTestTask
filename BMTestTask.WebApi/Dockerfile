FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BMTestTask.WebApi/BMTestTask.WebApi.csproj", "BMTestTask.WebApi/"]
RUN dotnet restore "BMTestTask.WebApi/BMTestTask.WebApi.csproj"
COPY . .
WORKDIR "/src/BMTestTask.WebApi"
RUN dotnet build "BMTestTask.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BMTestTask.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BMTestTask.WebApi.dll"]
