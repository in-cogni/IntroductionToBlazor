FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY BlazorAcademy/BlazorAcademy.csproj BlazorAcademy/
RUN dotnet restore "BlazorAcademy/BlazorAcademy.csproj"
COPY BlazorAcademy/ BlazorAcademy/
WORKDIR /src/BlazorAcademy
RUN dotnet build "BlazorAcademy.csproj" -c Release -o /app/build
RUN dotnet publish "BlazorAcademy.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BlazorAcademy.dll", "--urls", "http://0.0.0.0:10000"]