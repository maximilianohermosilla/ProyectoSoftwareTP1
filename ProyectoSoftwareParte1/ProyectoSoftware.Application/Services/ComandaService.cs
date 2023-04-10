using ProyectoSoftware.AccessData;
using ProyectoSoftware.AccessData.Commands;
using ProyectoSoftware.AccessData.Queries;
using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.Application.Services
{
    public class ComandaService
    {        
        private ComandaQuery comandaQuery;
        private ComandaCommand comandaCommand;

        public ComandaService(ProyectoSoftwareContext _context)
        {
            this.comandaQuery = new ComandaQuery(_context);
            this.comandaCommand = new ComandaCommand(_context);
        }
        public List<ComandaDTO> GetAll()
        {
            List<ComandaDTO> comandas = comandaQuery.GetAll();

            return comandas;
        }

        public void Insert(List<Mercaderia> listaProductos, FormaEntrega formaEntrega, int precio)
        {
            comandaCommand.Insert(listaProductos, formaEntrega, precio);
        }
    }
}
