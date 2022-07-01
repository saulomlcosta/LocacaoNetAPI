using LocacaoNetAPI.Application.Interfaces;
using LocacaoNetAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

public class FileUploadRequest
{
    public string UploaderName { get; set; }
    public string UploaderAddress { get; set; }
    public IFormFile File { get; set; }
}

namespace LocacaoNetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService filmeService;

        public FilmesController(IFilmeService filmeService)
        {
            this.filmeService = filmeService;
        }

        // GET: api/<FilmesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FilmesController>/5
        [HttpGet("{id:int}")]
        public ActionResult<Filme> GetById(int id)
        {
            return Ok(filmeService.GetById(id));
        }

        // POST api/<FilmesController>
        [HttpPost]
        public void Post([FromForm] FileUploadRequest formFile)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            IFormFile file = formFile.File;

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);

                using (var excelPack = new ExcelPackage(ms))
                {
                    var ws = excelPack.Workbook.Worksheets[0];
                    // Trabalhando com DataTable, para facilitar.
                    DataTable excelasTable = new DataTable();
                    foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                    {
                        //Buscando detalhe sobre a Coluna
                        if (!string.IsNullOrEmpty(firstRowCell.Text))
                        {
                            string firstColumn = string.Format("Column {0}", firstRowCell.Start.Column);
                            excelasTable.Columns.Add(true ? firstRowCell.Text : firstColumn);
                        }
                    }

                    var startRow = true ? 2 : 1;
                    //Buscando detalhe na linha
                    for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                    {
                        var wsRow = ws.Cells[rowNum, 1, rowNum, excelasTable.Columns.Count];
                        DataRow row = excelasTable.Rows.Add();

                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                    }

                    var retornoFilmes = JsonConvert.DeserializeObject<List<Filme>>(JsonConvert.SerializeObject(excelasTable));

                    if(retornoFilmes != null)
                        filmeService.Post(retornoFilmes);
                }
            }
        }

        // PUT api/<FilmesController>/5
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Filme filme)
        {
            filmeService.Put(id, filme);

            return NoContent();
        }

        // DELETE api/<FilmesController>/5
        [HttpDelete("{id:int}")]
        public ActionResult<Filme> Delete(int id)
        {
            filmeService.Delete(id);

            return NoContent();
        }
    }
}
