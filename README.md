# OnlineStoreProject

## Setup local development environment:

### Requirements:

- [.NET 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
- [Node.js 16](https://nodejs.org/en/)
- [Entity Framework Core tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- **Optional**: [Docker](https://www.docker.com/) if you want to run SQL Server with docker container.

### Setup with Docker and dotnet cli:

1. Change inside `OnlineStoreProject/Startup.cs` SQL Server to use Docker connection string what you can find inside `OnlineStoreProject/appsettings.Development.json`.

```csharp
services.AddDbContext<OnlineStoreContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("LocalDockerServer"))
```

2. Pull and run SQL Server Docker container:

```sh
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```

3. Move to `OnlineStoreProject/` and build the project `dotnet build`.
4. Run migrations inside `Migrations/` with command: `dotnet ef database update`. After it's completed you should now have the seeded database inside you docker SQL Server.
5. Now you can start backend by running `dotnet run`.
6. Next go to `Frontend/` directory and run `npm install`.
7. Open `Frontend/src/utils/config.js` and replace the `DEV_BACKEND_URL` and `IMAGE_URL` with the url and port where backend is running. (eg. `https://localhost:5001` and `https://localhost:5001/images/`)
8. Now you can start frontend by running in `Frontend/` directory: `HTTPS=true npm start`.
9. Open browser and go to: `http://localhost:3000`.

### Docker setup with script

You can also pull, start and setup that SQL Server docker image by running `docker_setup.sh` bash script. This script also runs migrations and updates the SQL Server.

**NOTE:** Remember that you need to have Docker, dotnet and dotnet ef cli installed so this script works.

### `build.sh`

Bash script for:

1. Installs frontend packages
2. Builds backend project
