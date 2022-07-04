using LocacaoNetAPI.Application.Interfaces;
using LocacaoNetAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Data;
using System.Globalization;

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
        public ActionResult<List<Filme>> Get()
        {
            return filmeService.Get();
        }

        // GET api/<FilmesController>/5
        [HttpGet("{id:int}")]
        public ActionResult<Filme> GetById(int id)
        {
            return Ok(filmeService.GetById(id));
        }

        ////POST api/<FilmesController>
        //[HttpPost]
        //public void Post([FromForm] FileUploadRequest formFile)
        //{
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //    IFormFile file = formFile.File;

        //    using (var ms = new MemoryStream())
        //    {
        //        file.CopyTo(ms);

        //        using (var excelPack = new ExcelPackage(ms))
        //        {
        //            var ws = excelPack.Workbook.Worksheets[0];
        //            // Trabalhando com DataTable, para facilitar.
        //            DataTable excelasTable = new DataTable();
        //            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
        //            {
        //                //Buscando detalhe sobre a Coluna
        //                if (!string.IsNullOrEmpty(firstRowCell.Text))
        //                {
        //                    string firstColumn = string.Format("Column {0}", firstRowCell.Start.Column);
        //                    excelasTable.Columns.Add(true ? firstRowCell.Text : firstColumn);
        //                }
        //            }

        //            var startRow = true ? 2 : 1;
        //            //Buscando detalhe na linha
        //            for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
        //            {
        //                var wsRow = ws.Cells[rowNum, 1, rowNum, excelasTable.Columns.Count];
        //                DataRow row = excelasTable.Rows.Add();

        //                foreach (var cell in wsRow)
        //                {
        //                    row[cell.Start.Column - 1] = cell.Text;
        //                }
        //            }

        //            var retornoFilmes = JsonConvert.DeserializeObject<List<Filme>>(JsonConvert.SerializeObject(excelasTable));

        //            if(retornoFilmes != null)
        //                filmeService.Post(retornoFilmes);
        //        }
        //    }
        //}

        [HttpPost("upload")]
        public IActionResult FileUpload(IFormFile file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var result = string.Empty;
            string worksheetsName = "data";

            bool firstRowIsHeader = false;
            var format = new ExcelTextFormat();
            format.Delimiter = ',';
            format.TextQualifier = '"';

            using (var reader = new System.IO.StreamReader(file.OpenReadStream()))
            using (ExcelPackage package = new ExcelPackage())
            {
                result = reader.ReadToEnd();
                ExcelWorksheet worksheet =
                package.Workbook.Worksheets.Add(worksheetsName);
                worksheet.Cells["A1"].LoadFromText(result, format, OfficeOpenXml.Table.TableStyles.Medium27, firstRowIsHeader);
            }

            string[] subs = result.Split("\r\n");

            List<Filme> filmes = new List<Filme>();

            for (var y = 1; y < subs.Length - 1; y++)
            {
                string[] itens = subs[y].Split(';');
          
                var filmeConvertido = new Filme { Id = Convert.ToInt32(itens[0]), Titulo = itens[1], ClassificacaoIndicativa = Convert.ToInt32(itens[2]), Lancamento = Convert.ToByte(itens[3]) };
                    
                filmes.Add(filmeConvertido);
            }

            if (filmes.Count > 0)
                filmeService.Post(filmes);

            return Ok(filmes);
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
