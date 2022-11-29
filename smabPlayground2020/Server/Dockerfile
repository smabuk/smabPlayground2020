#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
RUN dotnet --info
COPY ["smabPlayground2020/Server/smabPlayground2020.Server.csproj", "smabPlayground2020/Server/"]
COPY ["smabPlayground2020/Client/smabPlayground2020.Client.csproj", "smabPlayground2020/Client/"]
COPY ["smabPlayground2020/Shared/smabPlayground2020.Shared.csproj", "smabPlayground2020/Shared/"]
COPY ["smabPlayground2020/Smab.PlexInfo/Smab.PlexInfo.csproj", "smabPlayground2020/Smab.PlexInfo/"]
COPY ["smabPlayground2020/Smab.PlexInfo.Server/Smab.PlexInfo.Server.csproj", "smabPlayground2020/Smab.PlexInfo.Server/"]
COPY ["smabPlayground2020/Smab.PlexInfo.UI/Smab.PlexInfo.UI.csproj", "smabPlayground2020/Smab.PlexInfo.UI/"]
RUN dotnet restore "smabPlayground2020/Server/smabPlayground2020.Server.csproj"
COPY . .
WORKDIR "/src/smabPlayground2020/Server"
RUN dotnet build "smabPlayground2020.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "smabPlayground2020.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "smabPlayground2020.Server.dll"]