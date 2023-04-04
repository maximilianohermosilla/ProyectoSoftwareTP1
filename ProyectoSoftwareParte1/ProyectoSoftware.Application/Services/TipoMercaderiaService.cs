using ProyectoSoftware.AccessData.Queries;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class TipoMercaderiaService
    {
        public static List<TipoMercaderia> GetAll()
        {
            List<TipoMercaderia> tiposMercaderia = TipoMercaderiaQuery.GetAll();

            return tiposMercaderia;
        }
    }
}
