using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CelebrityGuessingGame.Migrations
{
    /// <inheritdoc />
    public partial class ChangeofuiandQAmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Celebrities");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OptionText = table.Column<string>(type: "TEXT", nullable: false),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    SelectedOptionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Options_SelectedOptionId",
                        column: x => x.SelectedOptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "QuestionText" },
                values: new object[,]
                {
                    { 1, "Is the celebrity male?" },
                    { 2, "Is the person tall, medium, or short?" },
                    { 3, "Is the person old, young, or middle-aged?" },
                    { 4, "Is the person alive?" },
                    { 5, "Is the person an actor?" },
                    { 6, "Is the person a singer?" },
                    { 7, "Is the person American?" },
                    { 8, "Is the person involved in sports?" },
                    { 9, "Is the person a politician?" },
                    { 10, "Has the person won any awards?" },
                    { 11, "Is the person known for their philanthropy?" },
                    { 12, "Is the person involved in business?" },
                    { 13, "Is the person associated with fashion?" },
                    { 14, "Is the person known internationally?" },
                    { 15, "Is the person a public speaker?" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Yes", 1 },
                    { 2, "No", 1 },
                    { 3, "Tall", 2 },
                    { 4, "Medium", 2 },
                    { 5, "Short", 2 },
                    { 6, "Old", 3 },
                    { 7, "Young", 3 },
                    { 8, "Middle-aged", 3 },
                    { 9, "Yes", 4 },
                    { 10, "No", 4 },
                    { 11, "Yes", 5 },
                    { 12, "No", 5 },
                    { 13, "Yes", 6 },
                    { 14, "No", 6 },
                    { 15, "Yes", 7 },
                    { 16, "No", 7 },
                    { 17, "Yes", 8 },
                    { 18, "No", 8 },
                    { 19, "Yes", 9 },
                    { 20, "No", 9 },
                    { 21, "Yes", 10 },
                    { 22, "No", 10 },
                    { 23, "Yes", 11 },
                    { 24, "No", 11 },
                    { 25, "Yes", 12 },
                    { 26, "No", 12 },
                    { 27, "Yes", 13 },
                    { 28, "No", 13 },
                    { 29, "Yes", 14 },
                    { 30, "No", 14 },
                    { 31, "Yes", 15 },
                    { 32, "No", 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_SelectedOptionId",
                table: "Answers",
                column: "SelectedOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.CreateTable(
                name: "Celebrities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Birthday = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    IsAlive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Nationality = table.Column<string>(type: "TEXT", nullable: false),
                    NetWorth = table.Column<decimal>(type: "TEXT", nullable: false),
                    Occupation = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celebrities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Celebrities",
                columns: new[] { "Id", "Age", "Birthday", "Gender", "Height", "IsAlive", "Name", "Nationality", "NetWorth", "Occupation" },
                values: new object[,]
                {
                    { 1, 58, "1962-07-03", "Male", 1.7, true, "Tom Cruise", "American", 570000000m, "[\"Actor\"]" },
                    { 2, 39, "1981-09-04", "Female", 1.6899999999999999, true, "Beyoncé", "American", 400000000m, "[\"Singer\",\"Actress\"]" }
                });
        }
    }
}
