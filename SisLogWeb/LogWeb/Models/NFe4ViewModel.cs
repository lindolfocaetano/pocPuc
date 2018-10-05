using System.Collections.Generic;

namespace LogWeb.Models
{
    public class NFe4ViewModel
    {
        public Endereco Endereco { get; set; }
        public Coordenadas Coordenadas { get; set; }
    }

    public class Coordenadas
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

    public class Endereco
    {
        public string XLgr { get; set; }
        public string Nro { get; set; }
        public string XBairro { get; set; }
        public string XMun { get; set; }
        public string CMun { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
    }
}
