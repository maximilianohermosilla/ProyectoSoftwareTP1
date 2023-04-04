using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Queries
{
    public class MercaderiaQuery
    {
        public static List<Mercaderia> GetAllByType(int tipoMercaderia)
        {
            using (var context = new ProyectoSoftwareContext())
            {
                List<Mercaderia> lista = context.Mercaderias.Where(m => m.TipoMercaderiaId == tipoMercaderia).ToList();

                return lista;
            }
        }
    }
}
