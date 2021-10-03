using Microsoft.EntityFrameworkCore.Migrations;

namespace MadWorld.API.Migrations.Postgres
{
    public partial class AddSecurityToSecurityReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientIpAddress",
                table: "SecurityReports",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "SecurityReports",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientIpAddress",
                table: "SecurityReports");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "SecurityReports");
        }
    }
}
