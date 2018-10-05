using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFreteApi.Dto
{
    public class CotarFreteDto
    {
        [Required]
        public string IdCidadeOrigem { get; set; }
        [Required]
        public string IdCidadeDestino { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public double Peso { get; set; }

        public double Largura { get; set; }

        public double Altura { get; set; }

        public double Comprimento { get; set; }

        public double Cubagem { get; set; }

        
    }
}
