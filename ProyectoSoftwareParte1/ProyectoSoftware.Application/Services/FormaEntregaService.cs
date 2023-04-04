using ProyectoSoftware.AccessData.Queries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class FormaEntregaService
    {
        public static List<FormaEntrega> GetAll()
        {
            List<FormaEntrega> formasEntrega = FormaEntregaQuery.GetAll();

            return formasEntrega;
        }
    }
}
