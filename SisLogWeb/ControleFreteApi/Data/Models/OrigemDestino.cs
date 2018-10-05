using System;
using System.Collections.Generic;

namespace ControleFreteApi.Data.Models
{
    public partial class OrigemDestino
    {
        public Guid IdOrigemDestino { get; set; }
        public string IdCidadeOrigem { get; set; }
        public string IdCidadeDestino { get; set; }

        public Cidade IdCidadeDestinoNavigation { get; set; }
        public Cidade IdCidadeOrigemNavigation { get; set; }
    }
}
