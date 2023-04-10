using ProyectoSoftware.AccessData;
using ProyectoSoftware.AccessData.Queries;
using ProyectoSoftware.Application.Services;
using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftwareParte1
{

    public class Menu
    {
        private static ProyectoSoftwareContext _context = new ProyectoSoftwareContext();

        private static TipoMercaderiaService tipoMercaderiaService = new TipoMercaderiaService(_context);
        private static FormaEntregaService formaEntregaService = new FormaEntregaService(_context);
        private static MercaderiaService mercaderiaService = new MercaderiaService(_context);
        private static ComandaService comandaService = new ComandaService(_context);

        public static List<Mercaderia> listaMercaderia = new List<Mercaderia>();
        public static List<Mercaderia> listaProductosPedido = new List<Mercaderia>();
        public static List<TipoMercaderia> tiposMercaderia = tipoMercaderiaService.GetAll();
        public static List<FormaEntrega> formasEntrega = formaEntregaService.GetAll();

        public static void MenuPrincipal()
        {
            string? opcion = "0";

            do
            {
                MenuCabecera("MENU PRINCIPAL", true);

                Console.WriteLine("1) Nuevo pedido");
                Console.WriteLine("2) Listar pedidos");
                Console.WriteLine("3) Salir");
                Console.Write("\r\nOpción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuNuevoPedido();
                        break;
                    case "2":
                        MenuListaPedidos();
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Opcion invalida. Intente de nuevo...");
                        Console.ReadKey(true);
                        break;
                }
            } while (opcion != "3");
        }

        public static void MenuNuevoPedido()
        {
            string? opcionTipoMercaderia = "";
            string? opcionMercaderia = "";
            string? opcionAgregar = "";
            int tipoMercaderiaId;
            int mercaderiaId;
            bool agregarProductos = true;

            try
            {
                do
                {
                    opcionTipoMercaderia = MenuTipoDeMercaderia();

                    if (int.TryParse(opcionTipoMercaderia, out tipoMercaderiaId))
                    {
                        opcionMercaderia = MenuMercaderias(tipoMercaderiaId);

                        if (int.TryParse(opcionMercaderia, out mercaderiaId))
                        {
                            AgregarProducto(mercaderiaId);
                        }

                        Console.WriteLine("\n¿Desea continuar agregando productos?");
                        Console.WriteLine("1) Si");
                        Console.WriteLine("2) No");
                        Console.Write("\r\nOpción: ");
                        opcionAgregar = Console.ReadLine();
                        agregarProductos = opcionAgregar != "2";
                    }

                } while (agregarProductos);

                if (listaProductosPedido.Count > 0)
                {
                    FormaEntrega formaEntrega = MenuFormasEntrega();
                    ConfirmacionPedido(listaProductosPedido, formaEntrega);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void MenuCabecera(string titulo, bool seleccionar)
        {
            Console.Clear();
            Console.WriteLine("PROYECTO SOFTWARE - TRABAJO PRACTICO PARTE 1");
            Console.WriteLine("--------------------------------------------\n");
            Console.WriteLine(@"{0}{1}", titulo, "\n");

            if (seleccionar)
            {
                Console.WriteLine("Seleccione una opción:");
            }
        }

        public static string MenuTipoDeMercaderia()
        {
            MenuCabecera("TIPO DE MERCADERIA", true);

            foreach (var item in tiposMercaderia)
            {
                Console.WriteLine(item.TipoMercaderiaId + ") " + item.Descripcion);
            }

            Console.Write("\r\nOpción: ");            
            return Console.ReadLine();
        }

        public static string MenuMercaderias(int tipoMercaderia)
        {
            string opcion = "";
            listaMercaderia = mercaderiaService.GetAllByType(tipoMercaderia);
            if (listaMercaderia.Count() > 0)
            {
                MenuCabecera("PRODUCTOS", true);
                foreach (var item in listaMercaderia)
                {
                    Console.WriteLine(item.MercaderiaId + ") " + item.Nombre);
                }

                Console.Write("\r\nOpción: ");
                opcion = Console.ReadLine();
            }
            else
            {
                MenuCabecera("TIPO DE MERCADERIA", false);
                Console.WriteLine("No existe el tipo de mercadería seleccionado");
                Thread.Sleep(1000);
            }

            return opcion;
        }

       public static void AgregarProducto(int mercaderiaId)
        {
            int cantidad;

            Mercaderia? producto = listaMercaderia.Where(x => x.MercaderiaId == mercaderiaId).FirstOrDefault();

            Console.Write("\r\nCantidad: ");
            string? opcionCantidad = Console.ReadLine();

            int.TryParse(opcionCantidad, out cantidad);

            MenuCabecera("AGREGAR PRODUCTO", false);

            if (producto != null && cantidad > 0)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    listaProductosPedido.Add(producto);
                }
                Console.WriteLine(@"¡Producto {0} agregado correctamente!{1}", producto.Nombre, "\n");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("No se pudo agregar el producto\n");
                Thread.Sleep(1000);
            }
        }

        public static FormaEntrega MenuFormasEntrega()
        {
            FormaEntrega formaEntrega;
            string? opcionFormaEntrega = "0";
            bool formaEntregaCorrecta = false;
            int opcionSeleccionada;
            do
            {
                MenuCabecera("FORMA DE ENTREGA", true);
                foreach (var item in formasEntrega)
                {
                    Console.WriteLine(item.FormaEntregaId + ") " + item.Descripcion);
                }

                Console.Write("\r\nOpción: ");
                opcionFormaEntrega = Console.ReadLine();
                int.TryParse(opcionFormaEntrega, out opcionSeleccionada);

                formaEntrega = formasEntrega.Where(x => x.FormaEntregaId == opcionSeleccionada).FirstOrDefault();
                formaEntregaCorrecta = formaEntrega != null;
            } while (!formaEntregaCorrecta);

            return formaEntrega;
        }

        public static void ConfirmacionPedido(List<Mercaderia> listaProductosPedido, FormaEntrega formaEntrega)
        {
            int precioFinal = 0;
            Console.Clear();
            Console.WriteLine("PEDIDO CONFIRMADO \n");
            foreach (var item in listaProductosPedido)
            {
                Console.WriteLine(item.Nombre + " $" + item.Precio);
                precioFinal += item.Precio;
            }
            Console.WriteLine(@"TOTAL = ${0}", precioFinal);
            Console.WriteLine(@"Forma de entrega: {0}", formaEntrega.Descripcion);
            Console.WriteLine("\nPresione una tecla para continuar...");

            comandaService.Insert(listaProductosPedido, formaEntrega, precioFinal);
            Console.ReadLine();
            listaProductosPedido.Clear();
        }

        public static void MenuListaPedidos()
        {
            Console.Clear();
            List<ComandaDTO> listaComandas = comandaService.GetAll();
            Console.WriteLine("LISTA DE COMANDAS");

            if(listaComandas.Count == 0)
            {
                Console.WriteLine("\nNo existen comandas ingresadas");
            }

            foreach (var item in listaComandas)
            {
                Console.WriteLine("\n_____________________________________________\n");
                Console.WriteLine(@"Comanda: {0}", item.ComandaId);
                Console.WriteLine("---------------------------------------------\n");

                foreach (var mercaderia in item.ComandaMercaderia)
                {
                    Console.WriteLine(@"({1}) {0} - ${2}", mercaderia.Nombre, mercaderia.TipoMercaderia, mercaderia.Precio);
                }
                Console.WriteLine("\n---------------------------------------------");
                Console.WriteLine(@"Precio Total: ${0}", item.PrecioTotal);
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(@"Forma de entrega: {0}", item.FormaEntrega);
                Console.WriteLine("_____________________________________________\n\n");
                Console.WriteLine("* * * * * * * * * * * * * * * * * * * * * * *");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");

            Console.ReadKey();
        }
    }
}
