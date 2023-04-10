using Microsoft.EntityFrameworkCore;
using ProyectoSoftware.AccessData;
using ProyectoSoftware.AccessData.Queries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class MercaderiaService
    {        
        private MercaderiaQuery mercaderiaQuery;

        public MercaderiaService(ProyectoSoftwareContext _context)
        {
            this.mercaderiaQuery = new MercaderiaQuery(_context);
        }

        public List<Mercaderia> GetAllByType(int tipoMercaderiaId)
        {
            List<Mercaderia> mercaderias = mercaderiaQuery.GetAllByType(tipoMercaderiaId);

            return mercaderias;
        }
    }
}
