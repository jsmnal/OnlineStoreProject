#!/bin/bash

echo Install frontend packages
npm --prefix ./Frontend install

echo Build backend
dotnet build ./OnlineStoreProject