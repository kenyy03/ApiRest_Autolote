using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TReparacion
    {
        public int IdReparacion { get; set; }
        public int IdAuto { get; set; }
        public int IdMecanico { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Costo { get; set; }

        public virtual TAuto IdAutoNavigation { get; set; }
        public virtual TMecanico IdMecanicoNavigation { get; set; }
    }
}
