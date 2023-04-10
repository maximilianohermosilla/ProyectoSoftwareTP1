using ProyectoSoftware.AccessData;
using ProyectoSoftware.AccessData.Queries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class TipoMercaderiaService
    {
        private TipoMercaderiaQuery tipoMercaderiaQuery;

        public TipoMercaderiaService(ProyectoSoftwareContext _context)
        {
            this.tipoMercaderiaQuery = new TipoMercaderiaQuery(_context);
        }

        public List<TipoMercaderia> GetAll()
        {
            List<TipoMercaderia> tiposMercaderia = tipoMercaderiaQuery.GetAll();

            return tiposMercaderia;
        }
    }
}
