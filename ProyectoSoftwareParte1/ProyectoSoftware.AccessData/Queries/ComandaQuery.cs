using ProyectoSoftware.Domain.DTO;
using ProyectoSoftware.Domain.Models;

namespace ProyectoSoftware.AccessData.Queries
{
    public class ComandaQuery
    {
        private ProyectoSoftwareContext context;

        public ComandaQuery(ProyectoSoftwareContext _context)
        {
            context = _context;
        }

        public List<ComandaDTO> GetAll()
        {
            
            List<Comanda> lista = context.Comandas.ToList();
            List<ComandaDTO> listaDTO = new List<ComandaDTO>();

            foreach (var item in lista)
            {
                ComandaDTO comandaDTO = new ComandaDTO(item);
                comandaDTO.FormaEntrega = context.FormasEntrega.Where(f => f.FormaEntregaId == item.FormaEntregaId).Select(f => f.Descripcion).FirstOrDefault();

                comandaDTO.ComandaMercaderia = (from m in context.Mercaderias
                                                join cm in context.ComandasMercaderia
                                                on m.MercaderiaId equals cm.MercaderiaId
                                                join tm in context.TiposMercaderia
                                                on m.TipoMercaderiaId equals tm.TipoMercaderiaId
                                                where cm.ComandaId == item.ComandaId
                                                select new MercaderiaDTO(m, tm.Descripcion)).ToList();

                listaDTO.Add(comandaDTO);
            }

            return listaDTO;
           

        }
    }
}
