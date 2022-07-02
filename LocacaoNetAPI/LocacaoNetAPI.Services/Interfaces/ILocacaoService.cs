using LocacaoNetAPI.Application.DTO;
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
        Locacao Post(LocacaoDTO locacaoDTO);
        bool Put(LocacaoDTO locacaoDTO);
        bool Delete(int id);  
    }
}
