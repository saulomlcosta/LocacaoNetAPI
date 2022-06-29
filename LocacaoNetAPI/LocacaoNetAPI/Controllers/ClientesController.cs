using LocacaoNetAPI.Data.Context;
using LocacaoNetAPI.Domain.Entities;
using LocacaoNetAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocacaoNetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly LocacaoNetAPIContext _context;
        private readonly IRepository<Cliente> _repository;

        public ClientesController(LocacaoNetAPIContext context, IRepository<Cliente> repository)
        {
            _context = context;
            _repository = repository;
        }


        // GET: api/<ClientesController>
        [HttpGet]
        public IActionResult Get()
        {
            var clientes = _context.Clientes.ToList();

            return Ok(clientes);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            _repository.Create(cliente);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
