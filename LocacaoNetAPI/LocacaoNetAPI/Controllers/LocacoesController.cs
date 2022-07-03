﻿using LocacaoNetAPI.Application.DTO;
using LocacaoNetAPI.Application.Interfaces;
using LocacaoNetAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocacaoNetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacoesController : ControllerBase
    {
        private readonly ILocacaoService locacaoService;

        public LocacoesController(ILocacaoService locacaoService)
        {
            this.locacaoService = locacaoService;
        }

        // GET: api/<LocacoesController>
        [HttpGet]
        public IEnumerable<Locacao> Get()
        {
            return locacaoService.Get();
        }

        // GET api/<LocacoesController>/5
        [HttpGet("{id:int}")]
        public ActionResult<Locacao> GetById(int id)
        {
            return Ok(locacaoService.GetById(id));
        }

        // POST api/<LocacoesController>
        [HttpPost]
        public IActionResult Post([FromBody] LocacaoDTO locacaoDTO)
        {
            var entity = locacaoService.Post(locacaoDTO);

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        // PUT api/<LocacoesController>/5
        [HttpPut("{id:int}")]
        public IActionResult Put(LocacaoDTO locacaoDTO)
        {
            locacaoService.Put(locacaoDTO);

            return NoContent();
        }

        // DELETE api/<LocacoesController>/5
        [HttpDelete("{id:int}")]
        public ActionResult<Locacao> Delete(int id)
        {
            locacaoService.Delete(id);

            return NoContent();
        }
    }
}