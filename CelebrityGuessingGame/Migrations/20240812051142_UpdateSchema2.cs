using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrityGuessingGame.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "Profession",
                table: "Celebrities",
                newName: "Occupation");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Celebrities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Birthday",
                table: "Celebrities",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Celebrities",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAlive",
                table: "Celebrities",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "NetWorth",
                table: "Celebrities",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Celebrities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "Birthday", "Height", "IsAlive", "NetWorth", "Occupation" },
                values: new object[] { 58, "1962-07-03", 1.7, true, 570000000m, "[\"Actor\"]" });

            migrationBuilder.UpdateData(
                table: "Celebrities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Age", "Birthday", "Height", "IsAlive", "NetWorth", "Occupation" },
                values: new object[] { 39, "1981-09-04", 1.6899999999999999, true, 400000000m, "[\"Singer\",\"Actress\"]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Celebrities");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Celebrities");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Celebrities");

            migrationBuilder.DropColumn(
                name: "IsAlive",
                table: "Celebrities");

            migrationBuilder.DropColumn(
                name: "NetWorth",
                table: "Celebrities");

            migrationBuilder.RenameColumn(
                name: "Occupation",
                table: "Celebrities",
                newName: "Profession");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Score = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Celebrities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Profession",
                value: "Actor");

            migrationBuilder.UpdateData(
                table: "Celebrities",
                keyColumn: "Id",
                keyValue: 2,
                column: "Profession",
                value: "Singer");
        }
    }
}
