using AutoMapper;
using LocacaoNetAPI.Application.DTO;
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
        private readonly ILocacaoRepository _repository;
        private readonly IMapper mapper;


        public LocacaoService(ILocacaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        public Locacao GetById(int id)
        {
            var _locacao = _repository.GetById(id);

            if (_locacao == null)
                throw new Exception("Locação não encontrada");

            return _locacao;
        }

        public Locacao Post(LocacaoDTO locacaoDTO)
        {
            Locacao _locacao = mapper.Map<Locacao>(locacaoDTO);

            return _repository.Create(_locacao);
        }

        public bool Put(LocacaoDTO locacaoDTO)
        {
            Locacao _locacao = _repository.Find(x => x.Id == locacaoDTO.Id);
            if (_locacao == null)
                throw new Exception("Locação não encontrada");

            _locacao = mapper.Map<Locacao>(locacaoDTO);

            return _repository.Update(_locacao);
        }

        public bool Delete(int id)
        {
            Locacao _locacao = _repository.Find(x => x.Id == id);
            if (_locacao == null)
                throw new Exception("Filme não encontrado");

            return _repository.Delete(_locacao);
        }
    }
}
