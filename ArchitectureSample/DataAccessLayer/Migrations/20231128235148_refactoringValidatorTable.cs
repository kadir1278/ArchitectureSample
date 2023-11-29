using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class refactoringValidatorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ValidatorName",
                schema: "dbo",
                table: "ValidationRule",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                schema: "dbo",
                table: "ValidationRule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationRule_ValidatorName",
                schema: "dbo",
                table: "ValidationRule",
                column: "ValidatorName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ValidationRule_ValidatorName",
                schema: "dbo",
                table: "ValidationRule");

            migrationBuilder.DropColumn(
                name: "Message",
                schema: "dbo",
                table: "ValidationRule");

            migrationBuilder.AlterColumn<string>(
                name: "ValidatorName",
                schema: "dbo",
                table: "ValidationRule",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
