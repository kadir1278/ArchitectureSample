using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class allTableDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ProjectOwner_ProjectOwnerId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropTable(
                name: "ProjectOwner",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_User_ProjectOwnerId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CultureInfo",
                schema: "dbo",
                table: "ValidationRule");

            migrationBuilder.DropColumn(
                name: "ProjectOwnerId",
                schema: "dbo",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CultureInfo",
                schema: "dbo",
                table: "ValidationRule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectOwnerId",
                schema: "dbo",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProjectOwner",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CultureInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectOwner", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_ProjectOwnerId",
                schema: "dbo",
                table: "User",
                column: "ProjectOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectOwner_Domain",
                schema: "dbo",
                table: "ProjectOwner",
                column: "Domain");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ProjectOwner_ProjectOwnerId",
                schema: "dbo",
                table: "User",
                column: "ProjectOwnerId",
                principalSchema: "dbo",
                principalTable: "ProjectOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
