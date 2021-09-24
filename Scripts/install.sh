#!/bash/sh

# Postgres Docker
docker pull postgres
docker run --name mad-world-db -e POSTGRES_PASSWORD=notmyrealpassword -e POSTGRES_DB=MadWorldDB -d -p 8080:5432 postgres

