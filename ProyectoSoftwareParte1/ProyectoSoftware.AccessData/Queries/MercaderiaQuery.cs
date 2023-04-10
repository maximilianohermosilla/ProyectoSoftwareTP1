using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Queries
{
    public class MercaderiaQuery
    {
        private ProyectoSoftwareContext context;
        public MercaderiaQuery(ProyectoSoftwareContext _context)
        {
            context = _context;
        }

        public List<Mercaderia> GetAllByType(int tipoMercaderia)
        {
            List<Mercaderia> lista = context.Mercaderias.Where(m => m.TipoMercaderiaId == tipoMercaderia).ToList();

            return lista;
        }
    }
}
