using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Infrastructure.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                nullable: false,
                defaultValue: 0);

           migrationBuilder.Sql(File.ReadAllText("../Infrastructure/Data/Seed/User.sql"));
           migrationBuilder.Sql(File.ReadAllText("../Infrastructure/Data/Seed/Empire.sql"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
