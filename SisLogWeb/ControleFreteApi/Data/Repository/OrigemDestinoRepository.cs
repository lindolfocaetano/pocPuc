using ControleFreteApi.Data.Interfaces;
using ControleFreteApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFreteApi.Data.Repository
{
    public class OrigemDestinoRepository : Repository<OrigemDestino>, IOrigemDestinoRepository
    {
        public OrigemDestinoRepository(SisLogFreteContext context) : base(context) { }

        public OrigemDestino GetByOrigemDestino(string idCidadeOrigem, string idCidadeDestino)
        {
            return _dbSet.Where(x => x.IdCidadeOrigem == idCidadeOrigem).Where(x => x.IdCidadeDestino == idCidadeDestino).FirstOrDefault();
        }
        public SisLogFreteContext SisLogFreteContext
        {
            get { return Context as SisLogFreteContext; }
        }
    }
}
