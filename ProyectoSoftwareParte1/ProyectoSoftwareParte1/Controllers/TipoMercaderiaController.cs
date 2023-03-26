using ProyectoSoftwareParte1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftwareParte1.Controllers
{
    public class TipoMercaderiaController
    {
        public static List<TipoMercaderia> GetAll()
        {
            using (var context = new ProyectoSoftwareContext())
            {                
                List<TipoMercaderia> lista = context.TiposMercaderia.ToList();

                return lista;
            }
        }
    }
}
