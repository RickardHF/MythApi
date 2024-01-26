# Steps taken


## Creating project 

```powershell
dotnet new web -o MythApi -f net8.0
```

## Importing packages 

```
dotnet add package Swashbuckle.AspNetCore --version 6.5.0
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

```powershell
# To build image
docker build -f Dockerfile . -t mythapi-image

# To create container
docker create --name mythapi-core mythapi-image

# To run the container with the image
docker run -d -p 5001:80 --name mythapi-container mythapi-test
```

```powershell
docker init
# <Make changes to compose.yaml>
docker compose up --build
```

```powershell
# install dotnet ef
dotnet tool install --global dotnet-ef

# create first migration
# pre requisite:
# dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0

# Create first migration
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update
```