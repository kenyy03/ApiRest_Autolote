using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DBModels
{
    public class Agente
    {
        public int IdAgente { get; set; }
        public int IdBase { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroTelefono { get; set; }
        public decimal? Salario { get; set; }
    }
}
