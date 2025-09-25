FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BlazorAcademy.csproj", "."]
RUN dotnet restore "BlazorAcademy.csproj"
COPY . .
RUN dotnet build "BlazorAcademy.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "BlazorAcademy.csproj" -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorAcademy.dll"]