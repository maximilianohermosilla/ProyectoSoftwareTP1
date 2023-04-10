using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Queries
{
    public class TipoMercaderiaQuery
    {
        private ProyectoSoftwareContext context;
        public TipoMercaderiaQuery(ProyectoSoftwareContext _context)
        {
            context = _context;
        }
        public List<TipoMercaderia> GetAll()
        {            
            List<TipoMercaderia> lista = context.TiposMercaderia.ToList();

            return lista;           
        }
    }
}
