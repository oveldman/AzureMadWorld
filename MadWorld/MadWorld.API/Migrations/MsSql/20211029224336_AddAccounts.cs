using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MadWorld.API.Migrations.MsSql
{
    public partial class AddAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AzureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAdminstrator = table.Column<bool>(type: "bit", nullable: false),
                    EmailAdress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
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
