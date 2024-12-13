using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_287.Migrations
{
    /// <inheritdoc />
    public partial class creationModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "couriel",
                table: "Users",
                newName: "Couriel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Couriel",
                table: "Users",
                newName: "couriel");
        }
    }
}
