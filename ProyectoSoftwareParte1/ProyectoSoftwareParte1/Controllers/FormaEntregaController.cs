using ProyectoSoftwareParte1.Models;

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
