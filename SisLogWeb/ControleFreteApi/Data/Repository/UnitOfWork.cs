using ControleFreteApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFreteApi.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SisLogFreteContext _context;

        public UnitOfWork(SisLogFreteContext context)
        {
            _context = context;
            BaseFretes = new BaseFreteRepository(_context);
            Cidades = new CidadeRepository(_context);
            FreteClientes = new FreteClienteRepository(_context);
            OrigemDestinos = new OrigemDestinoRepository(_context);

        }

        public IBaseFreteRepository BaseFretes { get; private set; }

        public ICidadeRepository Cidades { get; private set; }

        public IFreteClienteRepository FreteClientes { get; private set; }

        public IOrigemDestinoRepository OrigemDestinos { get; private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
