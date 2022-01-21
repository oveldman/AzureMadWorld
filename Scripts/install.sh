#!/bash/sh

# Postgres Docker
# First install Docker
docker pull postgres
docker run --name mad-world-db -e POSTGRES_PASSWORD=notmyrealpassword -e POSTGRES_DB=MadWorldDB -d -p 8080:5432 postgres

# NPM
# First install NPM
npm install -g azurite
npm install -g browserify
npm install -g typescript

# Dotnet Tools
dotnet tool install -g Microsoft.Web.LibraryManager.Cli