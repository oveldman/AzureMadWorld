#!/bash/sh
dotnet ef migrations add InitialCreate
dotnet ef migrations add InitialCreate -o ./Migrations/MsSql --context MadWorldContext
dotnet ef migrations add InitialCreate -o ./Migrations/Postgres --context MadWorldContextDev
dotnet ef database update
dotnet ef database update --context MadWorldContext
dotnet ef database update --context MadWorldContextDev
dotnet ef migrations script
dotnet ef migrations script --context MadWorldContext
dotnet ef migrations script --context MadWorldContextDev
dotnet ef migrations remove
dotnet ef migrations remove --context MadWorldContext
dotnet ef migrations remove --context MadWorldContextDev

#Update new certifate for the website
certbot certonly --manual --preferred-challenges dns  -d api.mad-world.nl
#Download file
#Fullchain.pem, cert.pem and privkey.pem
scp username@hostname:/path/to/remote/file /path/to/local/file
#Convert cert
openssl pkcs12 -export -out site.pfx -inkey privkey.pem -in cert.pem -certfile fullchain.pem

#Update dotnet tools
dotnet tool update dotnet-ef