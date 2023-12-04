using Microsoft.EntityFrameworkCore.Migrations;
using System.Globalization;

#nullable disable

namespace CommandAPI.Migrations
{
    public partial class AddNewRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText(string.Format(CultureInfo.InvariantCulture, "{0}{1}Migrations{1}SQL scripts{1}AddNewCommandItems.sql", ".", Path.DirectorySeparatorChar)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
