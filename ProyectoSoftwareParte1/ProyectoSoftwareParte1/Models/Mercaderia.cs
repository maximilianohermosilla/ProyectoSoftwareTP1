using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftwareParte1.Models
{
    [Table("Mercaderia")]
    public class Mercaderia
    {
        public int MercaderiaId { get; set; }
        public string Nombre { get; set; }
        public int TipoMercaderiaId { get; set; }
        public int Precio { get; set; }
        [StringLength(maximumLength:255)]
        public string Ingredientes { get; set; }
        [StringLength(maximumLength: 255)]
        public string Preparacion { get; set; }
        [StringLength(maximumLength: 255)]
        public string Imagen { get; set; }
    }
}
