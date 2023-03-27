using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftwareParte1.Models
{
    public class Mercaderia
    {
        public int MercaderiaId { get; set; }
        public string Nombre { get; set; }
        public int TipoMercaderiaId { get; set; }
        public int Precio { get; set; }        
        public string Ingredientes { get; set; }        
        public string Preparacion { get; set; }        
        public string Imagen { get; set; }

        public virtual TipoMercaderia TipoMercaderiaNavigation { get; set; }
        public IList<ComandaMercaderia> ComandasMercaderia { get; set; }
    }
}
