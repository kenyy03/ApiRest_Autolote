using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DBModels
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroTelefono { get; set; }
        public string Direccion { get; set; }
    }
}
