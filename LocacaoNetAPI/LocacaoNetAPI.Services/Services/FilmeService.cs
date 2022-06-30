using LocacaoNetAPI.Domain.Entities;
using LocacaoNetAPI.Domain.Interfaces;
using LocacaoNetAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoNetAPI.Services.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IRepository<Filme> _repository;

        public FilmeService(IRepository<Filme> repository)
        {
            _repository = repository;
        }

        public List<Filme> Get()
        {
            throw new NotImplementedException();
        }

        public Filme GetById(int id)
        {
            var filme = _repository.Get(w => w.Id == id);

            if (filme == null)
                throw new Exception("Filme não encontrado");

            return filme;
        }

        public List<Filme> Post(List<Filme> filmes)
        {
            return _repository.Create(filmes);
        }
    }
}
