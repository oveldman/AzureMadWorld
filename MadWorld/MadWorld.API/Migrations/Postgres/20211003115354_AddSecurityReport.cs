using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MadWorld.API.Migrations.Postgres
{
    public partial class AddSecurityReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Resumes",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternName = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    BlobName = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FileType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SecurityReports",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: true),
                    PublicKeyID = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityReports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SecurityReports_Files_PublicKeyID",
                        column: x => x.PublicKeyID,
                        principalTable: "Files",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecurityReportAttachments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    SecurityReportID = table.Column<Guid>(type: "uuid", nullable: false),
                    BlobFileID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityReportAttachments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SecurityReportAttachments_Files_BlobFileID",
                        column: x => x.BlobFileID,
                        principalTable: "Files",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecurityReportAttachments_SecurityReports_SecurityReportID",
                        column: x => x.SecurityReportID,
                        principalTable: "SecurityReports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecurityReportAttachments_BlobFileID",
                table: "SecurityReportAttachments",
                column: "BlobFileID");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityReportAttachments_SecurityReportID",
                table: "SecurityReportAttachments",
                column: "SecurityReportID");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityReports_PublicKeyID",
                table: "SecurityReports",
                column: "PublicKeyID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityReportAttachments");

            migrationBuilder.DropTable(
                name: "SecurityReports");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Resumes",
                type: "character varying(50)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
