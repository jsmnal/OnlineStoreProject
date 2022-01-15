#!/bin/bash

echo Starting SQL Server in docker
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest

echo Updating docker database from migrations
dotnet ef database update -p ./OnlineStoreProject