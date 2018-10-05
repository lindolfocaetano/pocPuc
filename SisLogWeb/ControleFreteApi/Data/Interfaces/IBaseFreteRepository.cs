using ControleFreteApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFreteApi.Data.Interfaces
{
    public interface IBaseFreteRepository : IRepository<BaseFrete>
    {
        BaseFrete GetByOrigemDestino(Guid idOrigemDestino);
    }
    
}
