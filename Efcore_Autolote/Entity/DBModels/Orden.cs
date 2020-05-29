using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DBModels
{
    public class Orden
    {
        public int IdOrden { get; set; }
        public int IdCliente { get; set; }
        public int IdAuto { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? RentaFechaInicio { get; set; }
        public DateTime? RentaFechaFin { get; set; }
        public DateTime? FechaCancelacion { get; set; }
    }
}
