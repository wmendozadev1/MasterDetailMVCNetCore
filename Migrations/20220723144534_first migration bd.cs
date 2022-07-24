using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestMVCNetCore.Migrations
{
    public partial class firstmigrationbd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Header",
                columns: table => new
                {
                    Header_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header_Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Header", x => x.Header_Id);
                });

            migrationBuilder.CreateTable(
                name: "Header_Detail",
                columns: table => new
                {
                    Header_Detail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header_Id = table.Column<int>(type: "int", nullable: false),
                    TypOption_Id = table.Column<int>(type: "int", nullable: false),
                    Header_Detail_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Header_Detail_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Header_Detail_Quantity = table.Column<float>(type: "real", nullable: false),
                    Header_Detail_Estimated = table.Column<float>(type: "real", nullable: false),
                    Header_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Header_Detail", x => x.Header_Detail_Id);
                    table.ForeignKey(
                        name: "FK_Header_Detail_Header_Header_Id1",
                        column: x => x.Header_Id1,
                        principalTable: "Header",
                        principalColumn: "Header_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Header_Detail_Header_Id1",
                table: "Header_Detail",
                column: "Header_Id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Header_Detail");

            migrationBuilder.DropTable(
                name: "Header");
        }
    }
}
