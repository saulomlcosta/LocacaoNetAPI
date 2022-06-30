using LocacaoNetAPI.Data.Context;
using LocacaoNetAPI.Domain.Entities;
using LocacaoNetAPI.Domain.Interfaces;
using LocacaoNetAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocacaoNetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService clienteService;

        private readonly IRepository<Cliente> _repository;


        public ClientesController(IClienteService clienteService, IRepository<Cliente> repository)
        {
            this.clienteService = clienteService;
            _repository = repository;
        }


        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return Ok(clienteService.Get());
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            return Ok(clienteService.GetById(id));
        }

        // POST api/<ClientesController>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            var entity = clienteService.Post(cliente);

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public  IActionResult Put(int id, Cliente cliente)
        {
             clienteService.Put(id, cliente);
            
            return NoContent();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id:int}")]
        public  ActionResult<Cliente> Delete(int id)
        {
             clienteService.Delete(id);

            return NoContent();
        }
    }
}
