using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiAutores.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarEntitiesComentarioAndReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "review",
                schema: "transacctional",
                table: "reviews",
                newName: "descripcion");

            migrationBuilder.RenameColumn(
                name: "texto",
                schema: "transacctional",
                table: "comentarios",
                newName: "descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "descripcion",
                schema: "transacctional",
                table: "reviews",
                newName: "review");

            migrationBuilder.RenameColumn(
                name: "descripcion",
                schema: "transacctional",
                table: "comentarios",
                newName: "texto");
        }
    }
}
