using ProyectoSoftwareParte1.Models;

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
