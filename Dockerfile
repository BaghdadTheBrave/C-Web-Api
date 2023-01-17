# Build stage

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
Workdir /source
copy . .

RUN dotnet restore "./BBEv2/BBEv2.csproj" --disable-parallel

RUN dotnet publish "./BBEv2/BBEv2.csproj" -c release -o /app --no-restore

# Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal 
WORKDIR /app
COPY --from=build /app ./

#to run on heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet BBEv2.dll

#to run locally
#EXPOSE 5000
#ENTRYPOINT ["dotnet","BBEv2.dll"]