using LocacaoNetAPI.Domain.Enums;
using LocacaoNetAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoNetAPI.Domain.Entities
{
    public class Locacao : Entity{

        public Cliente Cliente { get; set; }
        public int Id_Cliente { get; set; }
        public Filme Filme { get; set; }
        public int Id_Filme { get; set; }
        public DateTime DataLocacao { get; private set; } = DateTime.Now;
        public DateTime DataDevolucao { get; private set; } 

        public void AdicionarDataDevolucao(Filme Filme)
        {
            if(Filme.Lancamento == 1)
                DataDevolucao = DataLocacao.AddDays(2);
            else
                DataDevolucao = DataLocacao.AddDays(3);
        }
    }
}
