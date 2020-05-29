using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TBase
    {
        public TBase()
        {
            TAgente = new HashSet<TAgente>();
            TAuto = new HashSet<TAuto>();
            TMecanico = new HashSet<TMecanico>();
        }

        public int IdBase { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string NumeroTelefono { get; set; }

        public virtual ICollection<TAgente> TAgente { get; set; }
        public virtual ICollection<TAuto> TAuto { get; set; }
        public virtual ICollection<TMecanico> TMecanico { get; set; }
    }
}
