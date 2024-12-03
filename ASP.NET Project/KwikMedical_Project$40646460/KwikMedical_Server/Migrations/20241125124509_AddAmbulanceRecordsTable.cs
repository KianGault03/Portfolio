using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KwikMedical_Server.Migrations
{
    /// <inheritdoc />
    public partial class AddAmbulanceRecordsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmbulanceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientCHI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseWho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseWhat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseWhen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseWhere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmbulanceRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmbulanceRecords");
        }
    }
}
