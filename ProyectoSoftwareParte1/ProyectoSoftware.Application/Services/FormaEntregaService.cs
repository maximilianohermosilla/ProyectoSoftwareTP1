using ProyectoSoftware.AccessData;
using ProyectoSoftware.AccessData.Queries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class FormaEntregaService
    {
        private FormaEntregaQuery formaEntregaQuery;

        public FormaEntregaService(ProyectoSoftwareContext _context)
        {
            this.formaEntregaQuery = new FormaEntregaQuery(_context);
        }
        public List<FormaEntrega> GetAll()
        {
            List<FormaEntrega> formasEntrega = formaEntregaQuery.GetAll();

            return formasEntrega;
        }
    }
}
