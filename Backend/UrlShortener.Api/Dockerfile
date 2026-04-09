# Stage 1: Build Environment (Sử dụng SDK 9.0)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy file .csproj và restore các thư viện
COPY ["UrlShortener.Api.csproj", "./"]
RUN dotnet restore "UrlShortener.Api.csproj"

# Copy toàn bộ code còn lại và tiến hành build
COPY . .
RUN dotnet publish "UrlShortener.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime Environment (Sử dụng ASP.NET 9.0 Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080

# Chép các file đã build từ Stage 1 sang Stage 2
COPY --from=build /app/publish .

# Thiết lập cổng 8080 cho ứng dụng trong Docker
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "UrlShortener.Api.dll"]