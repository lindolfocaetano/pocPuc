using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogWeb.Models.CalculoFrete
{
    public class ValorFreteViewModel
    {
        public double VlFrete { get; set; }
        public DateTime DtCotacao { get; set; }
        public int PzEstimadoEntrega { get; set; }
        public string IdCidadeOrigem { get; set; }
        public string IdCidadeDestino { get; set; }
        public string CidadeOrigem { get; set; }
        public string CidadeDestino { get; set; }
        public string Email { get; set; }
        public double Cubagem { get; set; }
        public double Peso { get; set; }
        public string MetodoDeCalculo { get; set; }
        [Display(Name = "Largura")]
        public double Largura { get; set; }
        [Display(Name = "Altura")]
        public double Altura { get; set; }
        [Display(Name = "Comprimento")]
        public double Comprimento { get; set; }
    }
}
