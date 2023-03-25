using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoSoftwareParte1.Migrations
{
    /// <inheritdoc />
    public partial class ProyectoSoftware : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false),
                    PrecioTotal = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ComandaId);
                });

            migrationBuilder.CreateTable(
                name: "ComandaMercaderia",
                columns: table => new
                {
                    ComandaMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MercaderiaId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaMercaderia", x => x.ComandaMercaderiaId);
                });

            migrationBuilder.CreateTable(
                name: "FormaEntrega",
                columns: table => new
                {
                    FormaEntregaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaEntrega", x => x.FormaEntregaId);
                });

            migrationBuilder.CreateTable(
                name: "Mercaderia",
                columns: table => new
                {
                    MercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Ingredientes = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Preparacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercaderia", x => x.MercaderiaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMercaderia",
                columns: table => new
                {
                    TipoMercaderiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMercaderia", x => x.TipoMercaderiaId);
                });

            migrationBuilder.InsertData(
                table: "FormaEntrega",
                columns: new[] { "FormaEntregaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Salon" },
                    { 2, "Delivery" },
                    { 3, "Pedidos Ya" }
                });

            migrationBuilder.InsertData(
                table: "Mercaderia",
                columns: new[] { "MercaderiaId", "Imagen", "Ingredientes", "Nombre", "Precio", "Preparacion", "TipoMercaderiaId" },
                values: new object[,]
                {
                    { 1, "", "Jamón y Queso", "Empanada", 250, "Horno", 1 },
                    { 2, "", "Papa, Cheddar", "Papas fritas", 800, "Fritas", 2 },
                    { 3, "", "Jamón y Queso", "Sorrentinos", 1100, "Hervir", 3 },
                    { 4, "", "Ricota", "Ravioles", 1000, "Hervir", 3 },
                    { 5, "", "Papa, harina, manteca", "Ñoquis", 1050, "Hervir", 3 },
                    { 6, "", "Asado, vacío, chorizo, morcilla, riñon, molleja, entraña", "Parrillada para 2", 3200, "Parrilla a leña", 4 },
                    { 7, "", "Matambre de cerdo, salsa de tomate, jamón, muzzarella", "Matambre a la pizza", 2100, "Parrilla a leña", 4 },
                    { 8, "", "Harina, levadura, salsa de tomate, muzzarella", "Pizza Muzzarella", 1300, "Horno", 5 },
                    { 9, "", "Harina, levadura, salsa de tomate, muzzarella, jamón, morrón", "Pizza Especial", 1500, "Horno", 5 },
                    { 10, "", "Harina, levadura, salsa de tomate, muzzarella, tomate, orégano, ajo", "Pizza Napolitana", 1500, "Horno", 5 },
                    { 11, "", "Milanesa de ternera, pan", "Sandwich Milanesa Simple", 1000, "Frita", 6 },
                    { 12, "", "Milanesa de ternera, pan, lechuga, tomate, huevo", "Sandwich Milanesa Completo", 1300, "Frita", 6 },
                    { 13, "", "Hamburguesa, pan", "Hamburguesa Simple", 750, "Plancha", 6 },
                    { 14, "", "Hamburguesa, , lechuga, tomate, jamón, queso, huevo", "Hamburguesa Completa", 1000, "Plancha", 6 },
                    { 15, "", "Lechuga, tomate, cebolla", "Ensalada Simple", 600, "Ninguna", 7 },
                    { 16, "", "Papa, zanahoria, arvejas, huevo", "Ensalada Rusa", 700, "Hervir", 7 },
                    { 17, "", "No aplica", "Gaseosa", 500, "Ninguna", 8 },
                    { 18, "", "No aplica", "Agua mineral", 300, "Ninguna", 8 },
                    { 19, "", "Lúpulo, cebada, malta", "Cerveza IPA", 700, "Ninguna", 9 },
                    { 20, "", "Leche, huevo, azúcar", "Flan", 600, "Baño María", 10 }
                });

            migrationBuilder.InsertData(
                table: "TipoMercaderia",
                columns: new[] { "TipoMercaderiaId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Entrada" },
                    { 2, "Minutas" },
                    { 3, "Pastas" },
                    { 4, "Parrilla" },
                    { 5, "Pizzas" },
                    { 6, "Sandwich" },
                    { 7, "Ensaladas" },
                    { 8, "Bebidas" },
                    { 9, "Cerveza Artesanal" },
                    { 10, "Postres" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "ComandaMercaderia");

            migrationBuilder.DropTable(
                name: "FormaEntrega");

            migrationBuilder.DropTable(
                name: "Mercaderia");

            migrationBuilder.DropTable(
                name: "TipoMercaderia");
        }
    }
}
