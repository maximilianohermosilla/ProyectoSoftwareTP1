using Microsoft.Identity.Client;
using ProyectoSoftwareParte1.DTO;
using ProyectoSoftwareParte1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public static List<ComandaDTO> GetAll()
        {
            using (var context = new ProyectoSoftwareContext())
            {
                List<Comanda> lista = context.Comandas.ToList();
                List<ComandaDTO> listaDTO = new List<ComandaDTO>();

                foreach (var item in lista)
                {
                    ComandaDTO comandaDTO = new ComandaDTO(item);
                    comandaDTO.FormaEntrega = (from table in context.FormasEntrega where table.FormaEntregaId == item.FormaEntregaId select table.Descripcion).FirstOrDefault();

                    comandaDTO.ComandaMercaderia = (from m in context.Mercaderias
                                            join cm in context.ComandasMercaderia
                                            on m.MercaderiaId equals cm.MercaderiaId
                                            join tm in context.TiposMercaderia
                                            on m.TipoMercaderiaId equals tm.TipoMercaderiaId
                                            where cm.ComandaId == item.ComandaId
                                            select new MercaderiaDTO(m, tm.Descripcion)).ToList();

                    

                    listaDTO.Add(comandaDTO);
                }

                return listaDTO;
            }

        }
    }
}
