using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Infrastructure.Migrations
{
    public partial class AddInitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText("../Infrastructure/Data/Seed/Map.sql"));
            migrationBuilder.Sql(File.ReadAllText("../Infrastructure/Data/Seed/Game.sql"));
            migrationBuilder.Sql(File.ReadAllText("../Infrastructure/Data/Seed/Region.sql"));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
