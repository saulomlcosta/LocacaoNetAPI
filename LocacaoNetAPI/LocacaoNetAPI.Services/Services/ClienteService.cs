using LocacaoNetAPI.Domain.Entities;
using LocacaoNetAPI.Domain.Interfaces;
using LocacaoNetAPI.Application.Interfaces;


namespace LocacaoNetAPI.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IRepository<Cliente> _repository;

        public ClienteService(IRepository<Cliente> repository)
        {
            _repository = repository;
        }


        public List<Cliente> Get()
        {
            throw new NotImplementedException();
        }

    
        public Cliente GetById(int id)
        {
            var _cliente =  _repository.Get(w => w.Id == id);

            if (_cliente == null)
                throw new Exception("Cliente não encontrado");

            return _cliente;
        }

   
        public Cliente Post(Cliente cliente)
        {
            return _repository.Create(cliente);
        }

        public bool Put(int id, Cliente cliente)
        {
            Cliente _cliente = _repository.Find(x => x.Id == id);
            if (_cliente == null)
                throw new Exception("Cliente não encontrado");

            return  _repository.Update(cliente);
        }

        public bool Delete(int id)
        {
            Cliente _cliente = _repository.Find(x => x.Id == id);
            if (_cliente == null)
                throw new Exception("Cliente não encontrado");

            return  _repository.Delete(_cliente); 
        }
    }
}
