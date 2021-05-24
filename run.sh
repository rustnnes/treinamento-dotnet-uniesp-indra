#! /usr/bin/env bash
cd db
docker-compose up -d
cd ..

dotnet clean
dotnet restore

cd backend
dotnet ef database update
cd ..

dotnet run --project web/web.csproj