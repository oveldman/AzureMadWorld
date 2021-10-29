using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MadWorld.API.Migrations.Postgres
{
    public partial class AddAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    AzureID = table.Column<Guid>(type: "uuid", nullable: false),
                    IsAdminstrator = table.Column<bool>(type: "boolean", nullable: false),
                    EmailAdress = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
