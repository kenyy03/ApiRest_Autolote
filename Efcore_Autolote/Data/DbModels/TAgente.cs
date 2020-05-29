using System;
using System.Collections.Generic;

namespace Data.DbModels
{
    public partial class TAgente
    {
        public int IdAgente { get; set; }
        public int IdBase { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroTelefono { get; set; }
        public decimal? Salario { get; set; }

        public virtual TBase IdBaseNavigation { get; set; }
    }
}
