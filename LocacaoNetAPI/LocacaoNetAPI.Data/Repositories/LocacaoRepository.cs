using LocacaoNetAPI.Data.Context;
using LocacaoNetAPI.Domain.Entities;
using LocacaoNetAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoNetAPI.Data.Repositories
{
    public class LocacaoRepository : Repository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(LocacaoNetAPIContext context) : base(context)
        {
        }

        public Locacao GetById(int id)
        {
            var locacao = _context
                .Locacoes
                .Where(x => x.Id == id)
                .Include(f => f.Filme)
                .Include(c => c.Cliente)
                .FirstOrDefault();

            return locacao;
        }
    }
}
