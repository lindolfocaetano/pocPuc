using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFreteApi.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseFreteRepository BaseFretes { get; }
        ICidadeRepository Cidades { get; }
        IFreteClienteRepository FreteClientes { get; }
        IOrigemDestinoRepository OrigemDestinos { get; }
        int Commit();


    }
}
