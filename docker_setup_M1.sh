#!/bin/bash

echo Starting SQL Server in docker
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -e 'MSSQL_PID=Developer' -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge

echo Updating docker database from migrations
dotnet ef database update -p ./OnlineStoreProject