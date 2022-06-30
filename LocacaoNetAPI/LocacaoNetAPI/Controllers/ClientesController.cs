using LocacaoNetAPI.Data.Context;
using LocacaoNetAPI.Domain.Entities;
using LocacaoNetAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            var clientes = await _context.Clientes.AsNoTracking().ToListAsync();

            return Ok(clientes);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
                return NotFound(new { message = "Cliente não encontrado" });

            return Ok(cliente);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            await _repository.CreateAsync(cliente);

            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Cliente cliente)
        {
            Cliente _cliente = _repository.Find(x => x.Id == id);
            if (_cliente == null)
                throw new Exception("Cliente não encontrado");

            await _repository.UpdateAsync(cliente);

            return NoContent();
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            Cliente _cliente = _repository.Find(x => x.Id == id);
            if (_cliente == null)
                throw new Exception("Cliente não encontrado");

            await _repository.DeleteAsync(_cliente);

            return NoContent();
        }
    }
}
