using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TOrden
    {
        public int IdOrden { get; set; }
        public int IdCliente { get; set; }
        public int IdAuto { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? RentaFechaInicio { get; set; }
        public DateTime? RentaFechaFin { get; set; }
        public DateTime? FechaCancelacion { get; set; }

        public virtual TAuto IdAutoNavigation { get; set; }
        public virtual TCliente IdClienteNavigation { get; set; }
    }
}
