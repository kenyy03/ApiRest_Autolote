using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DBModels
{
    public class Base
    {
        public int IdBase { get; set; }
        public string Nombre { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string NumeroTelefono { get; set; }
    }
}
