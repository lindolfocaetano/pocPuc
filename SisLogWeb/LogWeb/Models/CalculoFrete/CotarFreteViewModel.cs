using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogWeb.Models.CalculoFrete
{
    public class CotarFreteViewModel
    {
        [Required]
        public string IdCidadeorigem { get; set; }
        [Required]
        public string IdCidadeDestino { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public double Peso { get; set; }

        [Display(Name ="Largura")]
        public double Largura { get; set; }

        [Display(Name = "Altura")]
        public double Altura { get; set; }

        [Display(Name = "Comprimento")]
        public double Comprimento { get; set; }

        public IEnumerable<CidadeViewModel> Cidades { get; set; }
    }
}
