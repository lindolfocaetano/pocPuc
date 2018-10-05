using ControleFreteApi.Data.Interfaces;
using ControleFreteApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFreteApi.Data.Repository
{
    public class BaseFreteRepository : Repository<BaseFrete>, IBaseFreteRepository
    {
        public BaseFreteRepository(SisLogFreteContext context) : base(context) { }

        public SisLogFreteContext SisLogFreteContext
        {
            get { return Context as SisLogFreteContext; }
        }

        public BaseFrete GetByOrigemDestino(Guid idOrigemDestino)
        {
            return _dbSet.Where(x => x.IdOrigemDestino == idOrigemDestino)
                .Where(x => x.VlAtivo == true)
                .FirstOrDefault();

        }

        //    private SisLogFreteContext _context;

        //    public BaseFreteRepository(SisLogFreteContext context)
        //    {
        //        _context = context;
        //    }

        //    public IEnumerable<BaseFrete> GetAll()
        //    {
        //        return _context.BaseFrete.AsEnumerable();
        //    }

        //    public BaseFrete GetById(Guid id)
        //    {
        //        return _context.BaseFrete.Find(id);
        //    }

        //    public BaseFrete GetByOrigemDestino(Guid IdOD)
        //    {
        //        return _context.BaseFrete.Where(x => x.IdOrigemDestino == IdOD).FirstOrDefault();
        //    }

        //    public bool Add(BaseFrete baseFrete)
        //    {
        //        try
        //        {
        //            _context.BaseFrete.Add(baseFrete);
        //            _context.SaveChanges();

        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            throw new Exception( "não inserido");
        //        }


        //    }

        //    public void RemoveAll()
        //    {   
        //        var dados = _context.BaseFrete.ToArray();
        //        _context.BaseFrete.RemoveRange(dados);
        //        _context.SaveChanges();
        //    }
    }
}
