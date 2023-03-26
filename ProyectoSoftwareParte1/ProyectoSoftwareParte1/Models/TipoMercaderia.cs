using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSoftwareParte1.Models
{    
    public class TipoMercaderia
    {
        public int TipoMercaderiaId { get; set; }        
        public string Descripcion { get; set; }
    }
}
