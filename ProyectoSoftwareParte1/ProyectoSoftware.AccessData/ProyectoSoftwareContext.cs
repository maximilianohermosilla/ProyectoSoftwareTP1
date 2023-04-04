using Microsoft.EntityFrameworkCore;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData
{
    public class ProyectoSoftwareContext : DbContext
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
            modelBuilder.Entity<Comanda>().ToTable("Comanda").HasOne<FormaEntrega>(s => s.FormaEntregaNavigation).WithMany(g => g.Comandas).HasForeignKey(s => s.FormaEntregaId);
            modelBuilder.Entity<ComandaMercaderia>().ToTable("ComandaMercaderia");
            modelBuilder.Entity<ComandaMercaderia>().HasOne<Comanda>(s => s.ComandaNavigation).WithMany(g => g.ComandasMercaderia).HasForeignKey(s => s.ComandaId);
            modelBuilder.Entity<ComandaMercaderia>().HasOne<Mercaderia>(s => s.MercaderiaNavigation).WithMany(g => g.ComandasMercaderia).HasForeignKey(s => s.MercaderiaId);
            modelBuilder.Entity<Mercaderia>().ToTable("Mercaderia").HasOne<TipoMercaderia>(s => s.TipoMercaderiaNavigation).WithMany(g => g.Mercaderias).HasForeignKey(s => s.TipoMercaderiaId);
            modelBuilder.Entity<FormaEntrega>().ToTable("FormaEntrega");
            modelBuilder.Entity<TipoMercaderia>().ToTable("TipoMercaderia");

            modelBuilder.Entity<Comanda>().Property(x => x.Fecha).HasColumnType("Date");
            modelBuilder.Entity<FormaEntrega>().Property(x => x.Descripcion).HasMaxLength(50);
            modelBuilder.Entity<Mercaderia>().Property(x => x.Nombre).HasMaxLength(50);
            modelBuilder.Entity<Mercaderia>().Property(x => x.Ingredientes).HasMaxLength(255);
            modelBuilder.Entity<Mercaderia>().Property(x => x.Preparacion).HasMaxLength(255);
            modelBuilder.Entity<Mercaderia>().Property(x => x.Imagen).HasMaxLength(255);
            modelBuilder.Entity<TipoMercaderia>().Property(x => x.Descripcion).HasMaxLength(50);

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
                new Mercaderia { MercaderiaId = 1, Nombre = "Empanada Jamón y Queso", TipoMercaderiaId = 1, Precio = 250, Ingredientes = "Jamón y Queso", Preparacion = "Horno", Imagen = "" },
                new Mercaderia { MercaderiaId = 2, Nombre = "Empanada Carne", TipoMercaderiaId = 1, Precio = 250, Ingredientes = "Carne, cebolla, morrón, huevo, salsa de tomate", Preparacion = "Horno", Imagen = "" },
                new Mercaderia { MercaderiaId = 3, Nombre = "Empanada Pollo", TipoMercaderiaId = 1, Precio = 250, Ingredientes = "Pollo, cebolla, morrón, huevo", Preparacion = "Horno", Imagen = "" },
                new Mercaderia { MercaderiaId = 4, Nombre = "Papas fritas", TipoMercaderiaId = 2, Precio = 800, Ingredientes = "Papa, sal", Preparacion = "Fritas", Imagen = "" },
                new Mercaderia { MercaderiaId = 5, Nombre = "Papas fritas con cheddar", TipoMercaderiaId = 2, Precio = 950, Ingredientes = "Papa, sal, Queso cheddar", Preparacion = "Fritas", Imagen = "" },
                new Mercaderia { MercaderiaId = 6, Nombre = "Bastones de muzzarella", TipoMercaderiaId = 2, Precio = 850, Ingredientes = "Muzzarella, pan rallado", Preparacion = "Fritas", Imagen = "" },
                new Mercaderia { MercaderiaId = 7, Nombre = "Sorrentinos", TipoMercaderiaId = 3, Precio = 1100, Ingredientes = "Harina, Jamón y Queso", Preparacion = "Hervir", Imagen = "" },
                new Mercaderia { MercaderiaId = 8, Nombre = "Ravioles", TipoMercaderiaId = 3, Precio = 1000, Ingredientes = "Harina, espinaca, ricota", Preparacion = "Hervir", Imagen = "" },
                new Mercaderia { MercaderiaId = 9, Nombre = "Ñoquis", TipoMercaderiaId = 3, Precio = 1050, Ingredientes = "Papa, harina, manteca", Preparacion = "Hervir", Imagen = "" },
                new Mercaderia { MercaderiaId = 10, Nombre = "Parrillada para 2", TipoMercaderiaId = 4, Precio = 3200, Ingredientes = "Asado, vacío, chorizo, morcilla, riñon, molleja, entraña", Preparacion = "Parrilla a leña", Imagen = "" },
                new Mercaderia { MercaderiaId = 11, Nombre = "Matambre a la pizza", TipoMercaderiaId = 4, Precio = 2100, Ingredientes = "Matambre de cerdo, salsa de tomate, jamón, muzzarella", Preparacion = "Parrilla a leña", Imagen = "" },
                new Mercaderia { MercaderiaId = 12, Nombre = "Pizza Muzzarella", TipoMercaderiaId = 5, Precio = 1300, Ingredientes = "Harina, levadura, salsa de tomate, muzzarella", Preparacion = "Horno", Imagen = "" },
                new Mercaderia { MercaderiaId = 13, Nombre = "Pizza Especial", TipoMercaderiaId = 5, Precio = 1500, Ingredientes = "Harina, levadura, salsa de tomate, muzzarella, jamón, morrón", Preparacion = "Horno", Imagen = "" },
                new Mercaderia { MercaderiaId = 14, Nombre = "Pizza Napolitana", TipoMercaderiaId = 5, Precio = 1500, Ingredientes = "Harina, levadura, salsa de tomate, muzzarella, tomate, orégano, ajo", Preparacion = "Horno", Imagen = "" },
                new Mercaderia { MercaderiaId = 15, Nombre = "Sandwich Milanesa Simple", TipoMercaderiaId = 6, Precio = 1000, Ingredientes = "Milanesa de ternera, pan", Preparacion = "Frita", Imagen = "" },
                new Mercaderia { MercaderiaId = 16, Nombre = "Sandwich Milanesa Completo", TipoMercaderiaId = 6, Precio = 1300, Ingredientes = "Milanesa de ternera, pan, lechuga, tomate, huevo", Preparacion = "Frita", Imagen = "" },
                new Mercaderia { MercaderiaId = 17, Nombre = "Hamburguesa Simple", TipoMercaderiaId = 6, Precio = 750, Ingredientes = "Hamburguesa carne, pan", Preparacion = "Plancha", Imagen = "" },
                new Mercaderia { MercaderiaId = 18, Nombre = "Hamburguesa Completa", TipoMercaderiaId = 6, Precio = 1000, Ingredientes = "Hamburguesa carne, lechuga, tomate, jamón, queso, huevo", Preparacion = "Plancha", Imagen = "" },
                new Mercaderia { MercaderiaId = 19, Nombre = "Ensalada Simple", TipoMercaderiaId = 7, Precio = 600, Ingredientes = "Lechuga, tomate, cebolla", Preparacion = "Ninguna", Imagen = "" },
                new Mercaderia { MercaderiaId = 20, Nombre = "Ensalada Rusa", TipoMercaderiaId = 7, Precio = 700, Ingredientes = "Papa, zanahoria, arvejas, huevo", Preparacion = "Hervir", Imagen = "" },
                new Mercaderia { MercaderiaId = 21, Nombre = "Gaseosa", TipoMercaderiaId = 8, Precio = 500, Ingredientes = "No aplica", Preparacion = "Ninguna", Imagen = "" },
                new Mercaderia { MercaderiaId = 22, Nombre = "Agua saborizada", TipoMercaderiaId = 8, Precio =450, Ingredientes = "No aplica", Preparacion = "Ninguna", Imagen = "" },
                new Mercaderia { MercaderiaId = 23, Nombre = "Agua mineral sin gas", TipoMercaderiaId = 8, Precio = 300, Ingredientes = "No aplica", Preparacion = "Ninguna", Imagen = "" },
                new Mercaderia { MercaderiaId = 24, Nombre = "Agua mineral con gas", TipoMercaderiaId = 8, Precio = 300, Ingredientes = "No aplica", Preparacion = "Ninguna", Imagen = "" },
                new Mercaderia { MercaderiaId = 25, Nombre = "Cerveza IPA", TipoMercaderiaId = 9, Precio = 750, Ingredientes = "Lúpulo, cebada, malta", Preparacion = "Ninguna", Imagen = "" },
                new Mercaderia { MercaderiaId = 26, Nombre = "Cerveza Scotish", TipoMercaderiaId = 9, Precio = 700, Ingredientes = "Lúpulo, cebada, malta, caramelo", Preparacion = "Ninguna", Imagen = "" },
                new Mercaderia { MercaderiaId = 27, Nombre = "Cerveza Stout", TipoMercaderiaId = 9, Precio = 750, Ingredientes = "Lúpulo, cebada, malta, cacao", Preparacion = "Ninguna", Imagen = "" },
                new Mercaderia { MercaderiaId = 28, Nombre = "Flan", TipoMercaderiaId = 10, Precio = 500, Ingredientes = "Leche, huevo, azúcar", Preparacion = "Baño María", Imagen = "" },
                new Mercaderia { MercaderiaId = 29, Nombre = "Helado", TipoMercaderiaId = 10, Precio = 600, Ingredientes = "Helado de chocolate, dulce de leche, vainilla", Preparacion = "No aplica", Imagen = "" },
                new Mercaderia { MercaderiaId = 30, Nombre = "Ensalada de frutas", TipoMercaderiaId = 10, Precio = 400, Ingredientes = "Manzana, Naranja, Banana, Ananá, Durazno, Cereza", Preparacion = "No aplica", Imagen = "" }
            );
        }
    }
}
