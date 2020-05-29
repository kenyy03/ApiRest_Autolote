using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TAuto
    {
        public TAuto()
        {
            TOrden = new HashSet<TOrden>();
            TReparacion = new HashSet<TReparacion>();
        }

        public int IdAuto { get; set; }
        public int IdBase { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumeroRegistro { get; set; }
        public int? AnioProduccion { get; set; }
        public decimal? PrecioRenta { get; set; }
        public string Categoria { get; set; }

        public virtual TBase IdBaseNavigation { get; set; }
        public virtual ICollection<TOrden> TOrden { get; set; }
        public virtual ICollection<TReparacion> TReparacion { get; set; }
    }
}
