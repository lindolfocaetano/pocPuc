using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFreteApi.Dto
{
    public class ValorFreteDto : CotarFreteDto
    {
        public double VlFrete { get; set; }
        public DateTime DtCotacao { get; set; }
        public int PzEstimadoEntrega { get; set; }
        public string IdCidadeOrigem { get; set; }
        public string MetodoDeCalculo { get; set; }
    }
}
