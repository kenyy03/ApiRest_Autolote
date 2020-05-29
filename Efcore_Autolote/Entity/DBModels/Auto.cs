using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DBModels
{
    public class Auto
    {
        public int IdAuto { get; set; }
        public int IdBase { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumeroRegistro { get; set; }
        public int? AnioProduccion { get; set; }
        public decimal? PrecioRenta { get; set; }
        public string Categoria { get; set; }
    }
}
