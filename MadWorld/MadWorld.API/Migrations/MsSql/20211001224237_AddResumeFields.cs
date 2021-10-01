using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MadWorld.API.Migrations.MsSql
{
    public partial class AddResumeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Resumes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Resumes");
        }
    }
}
