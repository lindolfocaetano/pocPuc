using ControleFreteApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFreteApi.Domain.Interface
{
    public interface ICidadeService
    {
        IEnumerable<CidadeDto> GetCidades();

        IEnumerable<CidadeDto> GetCidades(IEnumerable<string> IdCidades);
    }
}
