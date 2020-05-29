using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TMecanico
    {
        public TMecanico()
        {
            TReparacion = new HashSet<TReparacion>();
        }

        public int IdMecanico { get; set; }
        public int IdBase { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroTelefono { get; set; }
        public decimal? Salario { get; set; }
        public DateTime? FechaContratacion { get; set; }

        public virtual TBase IdBaseNavigation { get; set; }
        public virtual ICollection<TReparacion> TReparacion { get; set; }
    }
}
