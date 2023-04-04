﻿namespace ProyectoSoftware.Domain.Models
{
    public class FormaEntrega
    {
        public int FormaEntregaId { get; set; }
        public string Descripcion { get; set; }

        public IList<Comanda>? Comandas { get; set; }
    }
}
