using LocacaoNetAPI.Application.Interfaces;
using LocacaoNetAPI.Domain.Entities;
using LocacaoNetAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoNetAPI.Application.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly IRepository<Locacao> _repository;

        public LocacaoService(IRepository<Locacao> repository)
        {
            _repository = repository;
        }

        public Locacao GetById(int id)
        {
            var _locacao = _repository.Get(w => w.Id == id);

            if (_locacao == null)
                throw new Exception("Locação não encontrada");

            return _locacao;
        }
    }
}
