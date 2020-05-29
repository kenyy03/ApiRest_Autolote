using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DBModels
{
    public class Reparacion
    {
        public int IdReparacion { get; set; }
        public int IdAuto { get; set; }
        public int IdMecanico { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Costo { get; set; }
    }
}
