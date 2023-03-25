using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftwareParte1.Models
{
    public class ProyectoSoftwareContext: DbContext
    {
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<ComandaMercaderia> ComandasMercaderia { get; set; }
        public DbSet<FormaEntrega> FormasEntrega { get; set; }
        public DbSet<Mercaderia> Mercaderias { get; set; }
        public DbSet<TipoMercaderia> TiposMercaderia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ProyectoSoftware;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=localhost; Database=ProyectoSoftware; Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoMercaderia>().HasData(
                new TipoMercaderia { TipoMercaderiaId = 1, Descripcion = "Entrada" },
                new TipoMercaderia { TipoMercaderiaId = 2, Descripcion = "Minutas" },
                new TipoMercaderia { TipoMercaderiaId = 3, Descripcion = "Pastas" },
                new TipoMercaderia { TipoMercaderiaId = 4, Descripcion = "Parrilla" },
                new TipoMercaderia { TipoMercaderiaId = 5, Descripcion = "Pizzas" },
                new TipoMercaderia { TipoMercaderiaId = 6, Descripcion = "Sandwich" },
                new TipoMercaderia { TipoMercaderiaId = 7, Descripcion = "Ensaladas" },
                new TipoMercaderia { TipoMercaderiaId = 8, Descripcion = "Bebidas" },
                new TipoMercaderia { TipoMercaderiaId = 9, Descripcion = "Cerveza Artesanal" },
                new TipoMercaderia { TipoMercaderiaId = 10, Descripcion = "Postres" }            
            );

            modelBuilder.Entity<FormaEntrega>().HasData(
                new FormaEntrega { FormaEntregaId = 1, Descripcion = "Salon" },
                new FormaEntrega { FormaEntregaId = 2, Descripcion = "Delivery" },
                new FormaEntrega { FormaEntregaId = 3, Descripcion = "Pedidos Ya" }
            );

            modelBuilder.Entity<Mercaderia>().HasData(
                new Mercaderia { MercaderiaId = 1, Nombre = "Empanada", TipoMercaderiaId = 1, Precio = 250, Ingredientes = "Jamón y Queso", Preparacion = "Horno", Imagen = "" },
                new Mercaderia { MercaderiaId = 2, Nombre = "Papas fritas", TipoMercaderiaId = 2, Precio = 800, Ingredientes = "Papa, Cheddar", Preparacion = "Fritas", Imagen = "" },
                new Mercaderia { MercaderiaId = 3, Nombre = "Sorrentinos", TipoMercaderiaId = 3, Precio = 1100, Ingredientes = "Jamón y Queso", Preparacion = "Hervir", Imagen = "" },
                new Mercaderia { MercaderiaId = 4, Nombre = "Ravioles", TipoMercaderiaId = 3, Precio = 1000, Ingredientes = "Ricota", Preparacion = "Hervir", Imagen = "" },
                new Mercaderia { MercaderiaId = 5, Nombre = "Ñoquis", TipoMercaderiaId = 3, Precio = 1050, Ingredientes = "Papa, harina, manteca", Preparacion = "Hervir", Imagen = "" },
                new Mercaderia { MercaderiaId = 6, Nombre = "Parrillada para 2", TipoMercaderiaId = 4, Precio = 3200, Ingredientes = "Asado, vacío, chorizo, morcilla, riñon, molleja, entraña", Preparacion = "Parrilla a leña", Imagen = "" },
                new Mercaderia { MercaderiaId = 7, Nombre = "Matambre a la pizza", TipoMercaderiaId = 4, Precio = 2100, Ingredientes = "Matambre de cerdo, salsa de tomate, jamón, muzzarella", Preparacion = "Parrilla a leña", Imagen = "" },
                new Mercaderia { MercaderiaId = 8, Nombre = "Pizza Muzzarella", TipoMercaderiaId = 5, Precio = 1300, Ingredientes = "Harina, levadura, salsa de tomate, muzzarella", Preparacion = "Horno", Imagen = "" },
                new Mercaderia { MercaderiaId = 9, Nombre = "Pizza Especial", TipoMercaderiaId = 5, Precio = 1500, Ingredientes = "Harina, levadura, salsa de tomate, muzzarella, jamón, morrón", Preparacion = "Horno", Imagen = "" },
                new Mercaderia { MercaderiaId = 10, Nombre = "Pizza Napolitana", TipoMercaderiaId = 5, Precio = 1500, Ingredientes = "Harina, levadura, salsa de tomate, muzzarella, tomate, orégano, ajo", Preparacion = "Horno", Imagen = "" },
                new Mercaderia { MercaderiaId = 11, Nombre = "Sandwich Milanesa Simple", TipoMercaderiaId = 6, Precio = 1000, Ingredientes = "Milanesa de ternera, pan", Preparacion = "Frita", Imagen = "" },
                new Mercaderia { MercaderiaId = 12, Nombre = "Sandwich Milanesa Completo", TipoMercaderiaId = 6, Precio = 1300, Ingredientes = "Milanesa de ternera, pan, lechuga, tomate, huevo", Preparacion = "Frita", Imagen = "" },
                new Mercaderia { MercaderiaId = 13, Nombre = "Hamburguesa Simple", TipoMercaderiaId = 6, Precio = 750, Ingredientes = "Hamburguesa, pan", Preparacion = "Plancha", Imagen = "" },
                new Mercaderia { MercaderiaId = 14, Nombre = "Hamburguesa Completa", TipoMercaderiaId = 6, Precio = 1000, Ingredientes = "Hamburguesa, , lechuga, tomate, jamón, queso, huevo", Preparacion = "Plancha", Imagen = "" },
                new Mercaderia { MercaderiaId = 15, Nombre = "Ensalada Simple", TipoMercaderiaId = 7, Precio = 600, Ingredientes = "Lechuga, tomate, cebolla", Preparacion = "Ninguna", Imagen = "" },
                new Mercaderia { MercaderiaId = 16, Nombre = "Ensalada Rusa", TipoMercaderiaId = 7, Precio = 700, Ingredientes = "Papa, zanahoria, arvejas, huevo", Preparacion = "Hervir", Imagen = "" },
                new Mercaderia { MercaderiaId = 17, Nombre = "Gaseosa", TipoMercaderiaId = 8, Precio = 500, Ingredientes = "No aplica", Preparacion = "Ninguna", Imagen = "" },
                new Mercaderia { MercaderiaId = 18, Nombre = "Agua mineral", TipoMercaderiaId = 8, Precio = 300, Ingredientes = "No aplica", Preparacion = "Ninguna", Imagen = "" },
                new Mercaderia { MercaderiaId = 19, Nombre = "Cerveza IPA", TipoMercaderiaId = 9, Precio = 700, Ingredientes = "Lúpulo, cebada, malta", Preparacion = "Ninguna", Imagen = "" },
                new Mercaderia { MercaderiaId = 20, Nombre = "Flan", TipoMercaderiaId = 10, Precio = 600, Ingredientes = "Leche, huevo, azúcar", Preparacion = "Baño María", Imagen = "" }
            );
        }
    }
}
