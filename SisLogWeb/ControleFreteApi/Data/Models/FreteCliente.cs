using System;
using System.Collections.Generic;

namespace ControleFreteApi.Data.Models
{
    public partial class FreteCliente
    {
        public Guid IdFreteCliente { get; set; }
        public string Cnpj { get; set; }
        public string NmCliente { get; set; }
        public decimal? VlDesconto { get; set; }
        public Guid? IdCliente { get; set; }
        public string EmailCliente { get; set; }
        public DateTime? DtNegociacao { get; set; }
        public bool? VlAtivo { get; set; }
    }
}
