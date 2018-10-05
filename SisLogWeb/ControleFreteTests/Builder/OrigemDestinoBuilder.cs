using ControleFreteApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFreteTests.Builder
{
    class OrigemDestinoBuilder
    {
        public OrigemDestinoBuilder()
        {

        }

        public OrigemDestino ODGoianiaAparecida()
        {
            return new OrigemDestino
            {
                IdOrigemDestino = Guid.NewGuid(),
                IdCidadeOrigem = "5208707",
                IdCidadeDestino = "5201405"
            };
        }
    }
}
