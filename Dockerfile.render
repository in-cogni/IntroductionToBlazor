FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["BlazorAcademy/BlazorAcademy.csproj", "BlazorAcademy/"]
RUN dotnet restore "BlazorAcademy/BlazorAcademy.csproj"

COPY . .
WORKDIR "/src/BlazorAcademy"
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
COPY BlazorAcademy/app.db .
ENTRYPOINT ["dotnet", "BlazorAcademy.dll", "--urls", "http://0.0.0.0:10000"]