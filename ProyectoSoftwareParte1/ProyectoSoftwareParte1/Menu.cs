using ProyectoSoftwareParte1.Controllers;
using ProyectoSoftwareParte1.DTO;
using ProyectoSoftwareParte1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftwareParte1
{
    public class Menu
    {   
        public static List<TipoMercaderia> tiposMercaderia = TipoMercaderiaController.GetAll();
        public static List<FormaEntrega> formasEntrega = FormaEntregaController.GetAll();
        public static List<Mercaderia> listaMercaderia = new List<Mercaderia>();
        public static List<Mercaderia> listaProductosPedido = new List<Mercaderia>();        
        public static void MenuPrincipal()
        {
            string opcion = "0";

            do
            {
                MenuCabecera("MENU PRINCIPAL");

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
            string opcionTipoMercaderia = "0";                   
            string opcionMercaderia = "0";
            string opcionAgregar = "0";
            bool agregarProductos = true;
            int id;

            //AGREGO PRODUCTOS
            try
            {
                do
                {
                    //SELECCIONO TIPO DE MERCADERIA
                    MenuCabecera("TIPO DE MERCADERIA");

                    foreach (var item in tiposMercaderia)
                    {
                        Console.WriteLine(item.TipoMercaderiaId + ") " + item.Descripcion);
                    }

                    Console.Write("\r\nOpción: ");
                    opcionTipoMercaderia = Console.ReadLine();
                    bool validParse = int.TryParse(opcionTipoMercaderia, out id);
                    if (validParse)
                    {
                        listaMercaderia = MercaderiaController.GetAllByType(int.Parse(opcionTipoMercaderia));
                    }
                    else
                    {
                        Console.WriteLine("Opción incorrecta");
                        break;
                    }

                    //SELECCIONO PRODUCTOS DE LA CATEGORIA SELECCIONADA
                    MenuCabecera("PRODUCTOS");

                    foreach (var item in listaMercaderia)
                    {
                        Console.WriteLine(item.MercaderiaId + ") " + item.Nombre);
                    }

                    Console.Write("\r\nOpción: ");
                    opcionMercaderia = Console.ReadLine();

                    Mercaderia producto = listaMercaderia.Where(x => x.MercaderiaId == Int32.Parse(opcionMercaderia)).FirstOrDefault();

                    Console.Write("\r\nCantidad: ");
                    int opcionCantidad = int.Parse(Console.ReadLine());

                    Console.Clear();
                    Console.WriteLine("PROYECTO SOFTWARE - TRABAJO PRACTICO PARTE 1");
                    Console.WriteLine("--------------------------------------------\n");

                    //SI EL PRODUCTO EXISTE Y LA CANTIDAD ES VALIDA, AGREGO AL CARRO
                    if (producto != null && opcionCantidad > 0)
                    {
                        for (int i = 0; i < opcionCantidad; i++)
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

                    //DECIDO CONTINUAR AGREGANDO PRODUCTOS O SALIR
                    Console.WriteLine("¿Desea continuar agregando productos?");
                    Console.WriteLine("1) Si");
                    Console.WriteLine("2) No");
                    Console.Write("\r\nOpción: ");
                    opcionAgregar = Console.ReadLine();
                    agregarProductos = opcionAgregar != "2";
                } while (agregarProductos);

                FormaEntrega formaEntrega = MenuFormasEntrega();

                ConfirmacionPedido(listaProductosPedido, formaEntrega);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public static void MenuCabecera(string titulo)
        {
            Console.Clear();
            Console.WriteLine("PROYECTO SOFTWARE - TRABAJO PRACTICO PARTE 1");
            Console.WriteLine("--------------------------------------------\n");
            Console.WriteLine(@"{0}{1}", titulo, "\n");
            Console.WriteLine("Seleccione una opción:");
        }

        public static FormaEntrega MenuFormasEntrega()
        {
            FormaEntrega formaEntrega;
            string opcionFormaEntrega = "0";
            bool formaEntregaCorrecta = false;            
            do
            {
                MenuCabecera("FORMA DE ENTREGA");
                foreach (var item in formasEntrega)
                {
                    Console.WriteLine(item.FormaEntregaId + ") " + item.Descripcion);
                }

                Console.Write("\r\nOpción: ");
                opcionFormaEntrega = Console.ReadLine();

                formaEntrega = formasEntrega.Where(x => x.FormaEntregaId == Int32.Parse(opcionFormaEntrega)).FirstOrDefault();
                formaEntregaCorrecta = formaEntrega != null;
            } while (!formaEntregaCorrecta);

            return formaEntrega;
        }

        public static void ConfirmacionPedido(List<Mercaderia> listaProductosPedido, FormaEntrega formaEntrega)
        {
            int precioFinal = 0;
            foreach (var item in listaProductosPedido)
            {
                Console.WriteLine(item.Nombre + " $" + item.Precio);
                precioFinal += item.Precio;
            }
            Console.WriteLine(@"TOTAL = ${0}", precioFinal);
            Console.WriteLine(@"Forma de entrega: {0}", formaEntrega.Descripcion);

            ComandaController.NuevaComanda(listaProductosPedido, formaEntrega, precioFinal);

            Console.ReadLine();
        }

        public static void MenuListaPedidos()
        {
            Console.Clear();
            List<ComandaDTO> listaComandas = ComandaController.GetAll();

            foreach (var item in listaComandas)
            {
                Console.WriteLine(@"Comanda: {0}", item.ComandaId);
                Console.WriteLine("---------------------------------------------");

                foreach (var mercaderia in item.ComandaMercaderia)
                {
                    Console.WriteLine(@"{0} ({1}) ${2}", mercaderia.Nombre, mercaderia.TipoMercaderia, mercaderia.Precio);
                }

                Console.WriteLine(@"{0}Precio Total: ${1}", "\n", item.PrecioTotal);
                Console.WriteLine(@"Forma de entrega: {0}{1}", item.FormaEntrega, "\n");
            }

            Console.ReadLine();
        }
    }
}
