using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftwareParte1.Models
{
    public class ComandaMercaderia
    {
        public int ComandaMercaderiaId { get; set; }
        public int MercaderiaId { get; set; }
        public Guid ComandaId { get; set; }

        public virtual Mercaderia MercaderiaNavigation { get; set; }
        public virtual Comanda ComandaNavigation { get; set; }
    }
}
