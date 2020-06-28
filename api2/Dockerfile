FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS publish

WORKDIR /src

COPY . .

RUN dotnet restore "Api2.API/Api2.API.csproj"

RUN dotnet publish "Api2.API/Api2.API.csproj" \
	--configuration Release \
	--output /publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY --from=publish /publish .

EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "Api2.API.dll"]