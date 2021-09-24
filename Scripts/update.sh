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