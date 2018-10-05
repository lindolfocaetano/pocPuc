using System;
using System.Collections.Generic;

namespace ControleFreteApi.Data.Models
{
    public partial class BaseFrete
    {
        public Guid IdBaseFrete { get; set; }
        public decimal VlBase { get; set; }
        public string DtCadastro { get; set; }
        public bool VlAtivo { get; set; }
        public Guid IdOrigemDestino { get; set; }
    }
}
