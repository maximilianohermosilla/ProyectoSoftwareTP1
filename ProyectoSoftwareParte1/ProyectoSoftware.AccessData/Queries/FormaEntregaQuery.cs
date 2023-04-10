using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Queries
{
    public class FormaEntregaQuery
    {
        private ProyectoSoftwareContext context;

        public FormaEntregaQuery(ProyectoSoftwareContext _context)
        {
            context = _context;
        }

        public List<FormaEntrega> GetAll()
        {           
            List<FormaEntrega> lista = context.FormasEntrega.ToList();

            return lista;        
        }
    }
}
