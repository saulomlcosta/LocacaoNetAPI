using LocacaoNetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoNetAPI.Application.Interfaces
{
    public interface IFilmeService
    {
        Filme GetById(int id);
        List<Filme> Post(List<Filme> filmes);
    }
}
