using LocacaoNetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoNetAPI.Domain.Interfaces
{
    public interface ILocacaoRepository : IRepository<Locacao>
    {
        Locacao GetById(int id);
        List<Locacao> GetAll();
    }
    
}
