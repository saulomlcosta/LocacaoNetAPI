using LocacaoNetAPI.Application.DTO;
using LocacaoNetAPI.Application.Interfaces;
using LocacaoNetAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Table;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

public class UserInfo{
    public string UserName { get; set; }
    public int Age { get; set; }

}

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

        [HttpGet("FilmesMaisAlugadosAno")]
        public async Task<IActionResult> FilmesMaisAlugadosAno(CancellationToken cancellationToken)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // query data from database  
            await Task.Yield();
            var itens = locacaoService.FilmesMaisAlugadosAno();
           
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(itens, true);
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"FilmesMaisAlugadosAno-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }       
    }
}
