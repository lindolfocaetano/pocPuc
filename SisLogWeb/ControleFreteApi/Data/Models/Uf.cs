using System;
using System.Collections.Generic;

namespace ControleFreteApi.Data.Models
{
    public partial class Uf
    {
        public Uf()
        {
            Cidade = new HashSet<Cidade>();
        }

        public string IdUf { get; set; }
        public string NmUf { get; set; }
        public string SgUf { get; set; }

        public ICollection<Cidade> Cidade { get; set; }
    }
}
