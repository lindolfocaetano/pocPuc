using ControleFreteApi.Data.Interfaces;
using ControleFreteApi.Domain.Interface;
using ControleFreteApi.Dto;
using System.Collections.Generic;
using System.Linq;

namespace ControleFreteApi.Domain.Services
{
    public class CidadeService : ICidadeService
    {
        private IUnitOfWork _unitOfWork;

        public CidadeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IEnumerable<CidadeDto> GetCidades()
        {
            return _unitOfWork.Cidades.GetAll().Select(x => new CidadeDto
            {
                IdCidade = x.IdCidade,
                NmCidade = x.NmCidade,
                IdUf = x.IdUf
            }).ToArray();

        }

        public IEnumerable<CidadeDto>GetCidades(IEnumerable<string> IdCidades)
        {
            return _unitOfWork.Cidades.Find(x => IdCidades.Contains(x.IdCidade))
                .Select(y => new CidadeDto
                {
                    IdCidade = y.IdCidade,
                    IdUf = y.IdUf,
                    NmCidade = y.NmCidade
                }); ;
        }
    }
}
