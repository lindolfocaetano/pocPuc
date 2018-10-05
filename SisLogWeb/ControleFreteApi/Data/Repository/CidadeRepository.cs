using ControleFreteApi.Data.Interfaces;
using ControleFreteApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFreteApi.Data.Repository
{
    public class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(SisLogFreteContext context) : base(context) { }

        public SisLogFreteContext SisLogFreteContext
        {
            get { return Context as SisLogFreteContext; }
        }

    }
}
