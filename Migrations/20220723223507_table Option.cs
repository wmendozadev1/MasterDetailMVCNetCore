using Microsoft.EntityFrameworkCore.Migrations;

namespace TestMVCNetCore.Migrations
{
    public partial class tableOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeOption",
                columns: table => new
                {
                    TypOption_Id = table.Column<int>(type: "int", nullable: false),
                    TypOpt_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOption", x => x.TypOption_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeOption");
        }
    }
}
