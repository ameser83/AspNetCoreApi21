FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50121
EXPOSE 44398

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["AspNetCoreApi21/AspNetCoreApi21.csproj", "AspNetCoreApi21/"]
RUN dotnet restore "AspNetCoreApi21/AspNetCoreApi21.csproj"
COPY . .
WORKDIR "/src/AspNetCoreApi21"
RUN dotnet build "AspNetCoreApi21.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AspNetCoreApi21.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AspNetCoreApi21.dll"]