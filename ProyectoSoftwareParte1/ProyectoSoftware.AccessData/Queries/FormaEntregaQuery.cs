using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Queries
{
    public class FormaEntregaQuery
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
