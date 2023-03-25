using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftwareParte1.Models
{
    [Table("FormaEntrega")]
    public class FormaEntrega
    {
        public int FormaEntregaId { get; set; }
        [StringLength(maximumLength: 50)]
        public string Descripcion { get; set; }
    }
}
