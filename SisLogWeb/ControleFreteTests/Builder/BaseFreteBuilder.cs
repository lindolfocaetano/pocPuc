using ControleFreteApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFreteTests.Builder
{
    class BaseFreteBuilder
    {
        public BaseFreteBuilder()
        {

        }

        public BaseFrete BaseFreteGoianiaAparecida(Guid idOd)
        {
            return new BaseFrete
            {
                DtCadastro = DateTime.Now.ToShortDateString(),
                IdBaseFrete = Guid.NewGuid(),
                IdOrigemDestino = idOd,
                VlAtivo = true,
                VlBase = 1150
            };
        }
    }
}
