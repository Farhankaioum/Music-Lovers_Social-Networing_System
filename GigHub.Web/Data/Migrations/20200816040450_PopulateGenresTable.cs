using Microsoft.EntityFrameworkCore.Migrations;

namespace GigHub.Web.Data.Migrations
{
    public partial class PopulateGenresTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Genres (Id, Name) values (1, 'Jazz')");
            migrationBuilder.Sql("Insert into Genres (Id, Name) values (2, 'Blues')");
            migrationBuilder.Sql("Insert into Genres (Id, Name) values (3, 'Rock')");
            migrationBuilder.Sql("Insert into Genres (Id, Name) values (4, 'Country')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Genres Id IN (1,2,3,4)");
        }
    }
}
