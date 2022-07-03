using LocacaoNetAPI.Domain.Entities;
using LocacaoNetAPI.Domain.Interfaces;
using LocacaoNetAPI.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoNetAPI.Application.Services
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
            List<Filme> _filmes = _repository.GetAll();

            return _filmes;
        }

        public Filme GetById(int id)
        {
            var _filme = _repository.Get(w => w.Id == id);

            if (_filme == null)
                throw new Exception("Filme não encontrado");

            return _filme;
        }

        public List<Filme> Post(List<Filme> filmes)
        {
            return _repository.Create(filmes);
        }

        public bool Put(int id, Filme filme)
        {
            Filme _filme = _repository.Find(x => x.Id == id);
            if (_filme == null)
                throw new Exception("Filme não encontrado");

            return _repository.Update(filme);
        }

        public bool Delete(int id)
        {
            Filme _filme = _repository.Find(x => x.Id == id);
            if (_filme == null)
                throw new Exception("Filme não encontrado");

            return _repository.Delete(_filme);
        }
    }
}
