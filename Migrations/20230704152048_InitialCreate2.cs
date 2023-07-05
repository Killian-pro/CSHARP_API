using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_Categories",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_Products",
                table: "Game");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Player",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_PlayerName",
                table: "Player",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_Game",
                table: "Game",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_PlayerName",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_Game",
                table: "Game");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Player",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_Categories",
                table: "Player",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_Products",
                table: "Game",
                column: "Id");
        }
    }
}
