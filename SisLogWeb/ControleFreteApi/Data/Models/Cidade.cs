using System;
using System.Collections.Generic;

namespace ControleFreteApi.Data.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            OrigemDestinoIdCidadeDestinoNavigation = new HashSet<OrigemDestino>();
            OrigemDestinoIdCidadeOrigemNavigation = new HashSet<OrigemDestino>();
        }

        public string IdCidade { get; set; }
        public string NmCidade { get; set; }
        public string IdUf { get; set; }

        public Uf IdUfNavigation { get; set; }
        public ICollection<OrigemDestino> OrigemDestinoIdCidadeDestinoNavigation { get; set; }
        public ICollection<OrigemDestino> OrigemDestinoIdCidadeOrigemNavigation { get; set; }
    }
}
