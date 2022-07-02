using LocacaoNetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoNetAPI.Application.Interfaces
{
    public interface ILocacaoService
    {
        Locacao GetById(int id);
        //List<Filme> Post(List<Filme> filmes);
        //bool Put(int id, Filme filme);
        //bool Delete(int id);
    }
}
