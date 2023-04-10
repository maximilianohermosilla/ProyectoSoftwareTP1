using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Commands
{
    public class ComandaCommand
    {
        private ProyectoSoftwareContext context;

        public ComandaCommand(ProyectoSoftwareContext _context)
        {
            context = _context;
        }
        public void Insert(List<Mercaderia> listaProductos, FormaEntrega formaEntrega, int precio)
        {
            Comanda comanda = new Comanda();
            comanda.FormaEntregaId = formaEntrega.FormaEntregaId;
            comanda.PrecioTotal = precio;
            comanda.Fecha = DateTime.Now;
            
            context.Add(comanda);
            context.SaveChanges();

            foreach (var item in listaProductos)
            {
                ComandaMercaderia comandaMercaderia = new ComandaMercaderia();
                comandaMercaderia.MercaderiaId = item.MercaderiaId;
                comandaMercaderia.ComandaId = comanda.ComandaId;
                context.Add(comandaMercaderia);
                context.SaveChanges();
            }
           
        }
    }
}
