using ProyectoSoftwareParte1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftwareParte1.Controllers
{
    public class MercaderiaController
    {
        public static List<Mercaderia> GetAllByType(int tipoMercaderia)
        {
            using (var context = new ProyectoSoftwareContext())
            {
                List<Mercaderia> lista = (from table in context.Mercaderias where table.TipoMercaderiaId == tipoMercaderia select table).ToList();                

                return lista;
            }
        }
    }
}
