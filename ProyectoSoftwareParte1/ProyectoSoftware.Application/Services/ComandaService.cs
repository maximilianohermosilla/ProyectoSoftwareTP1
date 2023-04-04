using ProyectoSoftware.AccessData.Commands;
using ProyectoSoftware.AccessData.Queries;
using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class ComandaService
    {
        public static List<ComandaDTO> GetAll()
        {
            List<ComandaDTO> comandas = ComandaQuery.GetAll();

            return comandas;
        }

        public static void Insert(List<Mercaderia> listaProductos, FormaEntrega formaEntrega, int precio)
        {
            ComandaCommand.Insert(listaProductos, formaEntrega, precio);
        }
    }
}
