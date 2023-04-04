using ProyectoSoftware.AccessData.Queries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class MercaderiaService
    {
        public static List<Mercaderia> GetAllByType(int tipoMercaderiaId)
        {
            List<Mercaderia> mercaderias = MercaderiaQuery.GetAllByType(tipoMercaderiaId);

            return mercaderias;
        }
    }
}
