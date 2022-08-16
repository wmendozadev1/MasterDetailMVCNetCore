using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestMVCNetCore.Migrations
{
    public partial class TablesIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Company",
            //    columns: table => new
            //    {
            //        Comp_Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Comp_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Comp_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Comp_Active = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Company", x => x.Comp_Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserCompany",
            //    columns: table => new
            //    {
            //        UserComp_Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AspNetUser_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Comp_Id = table.Column<int>(type: "int", nullable: false),
            //        Act_Id = table.Column<int>(type: "int", nullable: false),
            //        UserComp_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UserComp_DisableDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        UserComp_Active = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserCompany", x => x.UserComp_Id);
            //    });

            migrationBuilder.CreateTable(
                name: "UserCompanyVM",
                columns: table => new
                {
                    UserComp_Id = table.Column<int>(type: "int", nullable: false),
                    Comp_Id = table.Column<int>(type: "int", nullable: false),
                    Comp_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AspNetUser_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Act_Id = table.Column<int>(type: "int", nullable: false),
                    Act_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Act_LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserComp_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserComp_DisableDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserComp_Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompanyVM", x => x.UserComp_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Company");

            //migrationBuilder.DropTable(
            //    name: "UserCompany");

            migrationBuilder.DropTable(
                name: "UserCompanyVM");
        }
    }
}
