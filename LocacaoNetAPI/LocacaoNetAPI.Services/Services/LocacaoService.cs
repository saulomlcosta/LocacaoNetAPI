using AutoMapper;
using LocacaoNetAPI.Application.DTO;
using LocacaoNetAPI.Application.Interfaces;
using LocacaoNetAPI.Data.Context;
using LocacaoNetAPI.Domain.Entities;
using LocacaoNetAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<Filme> _filmeRepository;
        private readonly IRepository<Cliente> _clienteRepository;
        private readonly LocacaoNetAPIContext _context;

        private readonly IMapper mapper;


        public LocacaoService(ILocacaoRepository repository, IMapper mapper, IRepository<Filme> filmeRepository, IRepository<Cliente> clienteRepository, LocacaoNetAPIContext context)
        {
            _repository = repository;
            this.mapper = mapper;
            _filmeRepository = filmeRepository;
            _clienteRepository = clienteRepository;
            _context = context;
        }

        public List<Locacao> Get()
        {
            List<Locacao> _locacoes = _repository.GetAll();          

            return _locacoes;
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

            var _filmeAlocado = _repository.Find(x => x.Id_Filme == locacaoDTO.Id_Filme);

            if(_filmeAlocado != null)
            {
                if (_filmeAlocado.DataDevolucao >= DateTime.Now)
                {
                    throw new ApplicationException("Filme já alocado");
                }
            }

            var _cliente = _clienteRepository.Find(x => x.Id == locacaoDTO.Id_Cliente);

            if (_cliente == null) throw new ApplicationException("Cliente não encontrado na base de dados");



            var _filme = _filmeRepository.Find(x => x.Id == locacaoDTO.Id_Filme);

            if (_filme == null) throw new ApplicationException("Filme não encontrado na base de dados");

            _locacao.AdicionarDataDevolucao(_filme);

            return _repository.Create(_locacao);
        }

        public bool Put(LocacaoDTO locacaoDTO)
        {
            Locacao _locacao = _repository.Find(x => x.Id == locacaoDTO.Id);
            if (_locacao == null)
                throw new Exception("Locação não encontrada");

            _locacao = mapper.Map<Locacao>(locacaoDTO);

            var _filmeAlocado = _repository.Find(x => x.Id_Filme == locacaoDTO.Id_Filme);

            if (_filmeAlocado != null)
            {
                if (_filmeAlocado.DataDevolucao >= DateTime.Now)
                {
                    throw new ApplicationException("Filme já alocado");
                }
            }

            var _cliente = _clienteRepository.Find(x => x.Id == locacaoDTO.Id_Cliente);

            if (_cliente == null) throw new ApplicationException("Cliente não encontrado na base de dados");

            var _filme = _filmeRepository.Find(x => x.Id == locacaoDTO.Id_Filme);

            if (_filme == null) throw new ApplicationException("Filme não encontrado na base de dados");


            _locacao.AdicionarDataDevolucao(_filme);

            return _repository.Update(_locacao);
        }

        public bool Delete(int id)
        {
            Locacao _locacao = _repository.Find(x => x.Id == id);
            if (_locacao == null)
                throw new Exception("Filme não encontrado");

            return _repository.Delete(_locacao);
        }

        public List<FilmesMaisAlugadosDTO> FilmesMaisAlugadosAno()
        {
            var filmes = _context
                .Locacoes
                .Include(i => i.Filme)
                .Where(x => x.DataLocacao.Year == DateTime.Now.Year)
                .GroupBy(g => g.Filme.Titulo)
                .Select(s => new FilmesMaisAlugadosDTO { Titulo = s.Key, Quantidade = s.Count() })
                .OrderByDescending(o => o.Quantidade)
                .Take(5)
                .ToList();

            return filmes;
        }      
    }
}
