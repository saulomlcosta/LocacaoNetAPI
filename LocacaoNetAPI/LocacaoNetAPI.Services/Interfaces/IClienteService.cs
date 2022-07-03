using LocacaoNetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoNetAPI.Application.Interfaces
{
    public interface IClienteService
    {
        List<Cliente> Get();

        Cliente GetById(int id);

        Cliente Post(Cliente cliente);

        bool Put(int id, Cliente cliente);

        bool Delete(int id);
    }
}
