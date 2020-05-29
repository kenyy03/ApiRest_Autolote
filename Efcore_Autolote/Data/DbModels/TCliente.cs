using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TCliente
    {
        public TCliente()
        {
            TOrden = new HashSet<TOrden>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroTelefono { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<TOrden> TOrden { get; set; }
    }
}
