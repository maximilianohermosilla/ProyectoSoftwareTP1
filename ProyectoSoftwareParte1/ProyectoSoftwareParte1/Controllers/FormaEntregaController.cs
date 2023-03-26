using ProyectoSoftwareParte1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftwareParte1.Controllers
{
    public class FormaEntregaController
    {
        public static List<FormaEntrega> GetAll()
        {
            using (var context = new ProyectoSoftwareContext())
            {
                List<FormaEntrega> lista = context.FormasEntrega.ToList();

                return lista;
            }
        }
    }
}
