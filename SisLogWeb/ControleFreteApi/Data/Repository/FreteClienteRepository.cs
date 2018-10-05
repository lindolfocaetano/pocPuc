using ControleFreteApi.Data.Interfaces;
using ControleFreteApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFreteApi.Data.Repository
{
    public class FreteClienteRepository : Repository<FreteCliente>, IFreteClienteRepository
    {
        public FreteClienteRepository(SisLogFreteContext context) : base(context) { }

        public SisLogFreteContext SisLogFreteContext
        {
            get { return Context as SisLogFreteContext; }
        }

        public FreteCliente GetByEmail(string email)
        {
            return _dbSet.Where(x => x.EmailCliente == email).FirstOrDefault();
        }
    }
}
