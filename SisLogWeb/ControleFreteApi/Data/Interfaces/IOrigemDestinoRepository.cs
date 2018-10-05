using ControleFreteApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFreteApi.Data.Interfaces
{
    public interface IOrigemDestinoRepository : IRepository<OrigemDestino>
    {
        OrigemDestino GetByOrigemDestino(string idCidadeOrigem, string idCidadeDestino);
    }
}
