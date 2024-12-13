using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_287.Migrations
{
    /// <inheritdoc />
    public partial class creationLiensEntreModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAdresse",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdExemplaire",
                table: "Loans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUtilisateur",
                table: "Loans",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLivre",
                table: "Copies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAuteur",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEmprunt",
                table: "Bills",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdAdresse",
                table: "Users",
                column: "IdAdresse");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_IdExemplaire",
                table: "Loans",
                column: "IdExemplaire");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_IdUtilisateur",
                table: "Loans",
                column: "IdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Copies_IdLivre",
                table: "Copies",
                column: "IdLivre");

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdAuteur",
                table: "Books",
                column: "IdAuteur");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_IdEmprunt",
                table: "Bills",
                column: "IdEmprunt");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Loans_IdEmprunt",
                table: "Bills",
                column: "IdEmprunt",
                principalTable: "Loans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_IdAuteur",
                table: "Books",
                column: "IdAuteur",
                principalTable: "Authors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Books_IdLivre",
                table: "Copies",
                column: "IdLivre",
                principalTable: "Books",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Copies_IdExemplaire",
                table: "Loans",
                column: "IdExemplaire",
                principalTable: "Copies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_IdUtilisateur",
                table: "Loans",
                column: "IdUtilisateur",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_IdAdresse",
                table: "Users",
                column: "IdAdresse",
                principalTable: "Addresses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Loans_IdEmprunt",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_IdAuteur",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Books_IdLivre",
                table: "Copies");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Copies_IdExemplaire",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_IdUtilisateur",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_IdAdresse",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdAdresse",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Loans_IdExemplaire",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_IdUtilisateur",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Copies_IdLivre",
                table: "Copies");

            migrationBuilder.DropIndex(
                name: "IX_Books_IdAuteur",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Bills_IdEmprunt",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "IdAdresse",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdExemplaire",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "IdUtilisateur",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "IdLivre",
                table: "Copies");

            migrationBuilder.DropColumn(
                name: "IdAuteur",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IdEmprunt",
                table: "Bills");
        }
    }
}
