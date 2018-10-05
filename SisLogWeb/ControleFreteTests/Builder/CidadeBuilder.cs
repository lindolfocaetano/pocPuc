using ControleFreteApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFreteTests.Builder
{
    class CidadeBuilder
    {
        public CidadeBuilder()
        {

        }

        public Cidade Cidade()
        {
            Cidade cidade = new Cidade { IdCidade = "5208707", NmCidade = "Goiânia", IdUf = "52" };
            return cidade;
        }

        public IEnumerable<Cidade> Cidades()
        {
            List<Cidade> cidades = new List<Cidade>
            {
                new Cidade { IdCidade = "5208707", NmCidade = "Goiânia", IdUf = "52" },
                new Cidade { IdCidade = "5201405", NmCidade = "Aparec", IdUf = "52" }
            };
            return cidades;
        }

    }
}
