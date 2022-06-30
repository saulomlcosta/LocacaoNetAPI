using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoNetAPI.Domain.Models
{
    public class FileUploadRequest
    {
        public string UploaderName { get; set; }
        public string UploaderAddress { get; set; }
        //public IFormFile File { get; set; }      
    }
}
