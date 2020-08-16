using Microsoft.EntityFrameworkCore.Migrations;

namespace GigHub.Web.Data.Migrations
{
    public partial class ModifiedGigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Genres_GenreId1",
                table: "Gigs");

            migrationBuilder.DropIndex(
                name: "IX_Gigs_GenreId1",
                table: "Gigs");

            migrationBuilder.DropColumn(
                name: "GenreId1",
                table: "Gigs");

            migrationBuilder.AlterColumn<byte>(
                name: "GenreId",
                table: "Gigs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Gigs_GenreId",
                table: "Gigs",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Genres_GenreId",
                table: "Gigs",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Genres_GenreId",
                table: "Gigs");

            migrationBuilder.DropIndex(
                name: "IX_Gigs_GenreId",
                table: "Gigs");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "Gigs",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AddColumn<byte>(
                name: "GenreId1",
                table: "Gigs",
                type: "tinyint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gigs_GenreId1",
                table: "Gigs",
                column: "GenreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Genres_GenreId1",
                table: "Gigs",
                column: "GenreId1",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
