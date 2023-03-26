using Microsoft.Identity.Client;
using ProyectoSoftwareParte1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftwareParte1.Controllers
{
    public class ComandaController
    {
        public static void NuevaComanda(List<Mercaderia> listaProductos, FormaEntrega formaEntrega, int precio)
        {
            Comanda comanda = new Comanda();
            comanda.FormaEntregaId = formaEntrega.FormaEntregaId;
            comanda.PrecioTotal = precio;
            comanda.Fecha = DateTime.Now;

            using (var context = new ProyectoSoftwareContext())
            {
                context.Add(comanda);
                context.SaveChanges();

                foreach (var item in listaProductos) 
                {
                    ComandaMercaderia comandaMercaderia = new ComandaMercaderia();
                    comandaMercaderia.MercaderiaId = item.MercaderiaId;
                    comandaMercaderia.ComandaId = comanda.ComandaId;
                    context.Add(comandaMercaderia);
                    context.SaveChanges();
                }
            }


        }
    }
}
