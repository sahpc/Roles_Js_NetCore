using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roles.Migrations
{
    /// <inheritdoc />
    public partial class relacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StocModelsId",
                table: "DetalleFactura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockModelId",
                table: "DetalleFactura",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_StockModelId",
                table: "DetalleFactura",
                column: "StockModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFactura_Stocks_StockModelId",
                table: "DetalleFactura",
                column: "StockModelId",
                principalTable: "Stocks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFactura_Stocks_StockModelId",
                table: "DetalleFactura");

            migrationBuilder.DropIndex(
                name: "IX_DetalleFactura_StockModelId",
                table: "DetalleFactura");

            migrationBuilder.DropColumn(
                name: "StocModelsId",
                table: "DetalleFactura");

            migrationBuilder.DropColumn(
                name: "StockModelId",
                table: "DetalleFactura");
        }
    }
}
