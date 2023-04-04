using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Queries
{
    public class TipoMercaderiaQuery
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
