FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/OnlineAuction.Web.Host/OnlineAuction.Web.Host.csproj", "src/OnlineAuction.Web.Host/"]
COPY ["src/OnlineAuction.Web.Core/OnlineAuction.Web.Core.csproj", "src/OnlineAuction.Web.Core/"]
COPY ["src/OnlineAuction.Application/OnlineAuction.Application.csproj", "src/OnlineAuction.Application/"]
COPY ["src/OnlineAuction.Core/OnlineAuction.Core.csproj", "src/OnlineAuction.Core/"]
COPY ["src/OnlineAuction.EntityFrameworkCore/OnlineAuction.EntityFrameworkCore.csproj", "src/OnlineAuction.EntityFrameworkCore/"]
WORKDIR "/src/src/OnlineAuction.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/OnlineAuction.Web.Host", "src/OnlineAuction.Web.Host"]
COPY ["src/OnlineAuction.Web.Core", "src/OnlineAuction.Web.Core"]
COPY ["src/OnlineAuction.Application", "src/OnlineAuction.Application"]
COPY ["src/OnlineAuction.Core", "src/OnlineAuction.Core"]
COPY ["src/OnlineAuction.EntityFrameworkCore", "src/OnlineAuction.EntityFrameworkCore"]
WORKDIR "/src/src/OnlineAuction.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "OnlineAuction.Web.Host.dll"]
