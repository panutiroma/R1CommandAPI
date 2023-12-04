using Microsoft.EntityFrameworkCore.Migrations;
using System.Globalization;

#nullable disable

namespace CommandAPI.Migrations
{
    public partial class AddOther2Records : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText(string.Format(CultureInfo.InvariantCulture, "{0}{1}Migrations{1}SQL scripts{1}AddOther2CommandItems_UP.sql", ".", Path.DirectorySeparatorChar)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText(string.Format(CultureInfo.InvariantCulture, "{0}{1}Migrations{1}SQL scripts{1}AddOther2CommandItems_DOWN.sql", ".", Path.DirectorySeparatorChar)));
        }
    }
}
