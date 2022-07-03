using LocacaoNetAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoNetAPI.Domain.Entities
{
    public class Locacao : Entity
    {
        public Cliente Cliente { get; set; }
        public int Id_Cliente { get; set; }
        public Filme Filme { get; set; }
        public int Id_Filme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
