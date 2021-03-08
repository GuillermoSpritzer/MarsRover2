using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Cambium.MarsRover.Web.Model
{
    public class RoverFiles
    {
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }
        public int PlateauWidth { get; set; }
        public int PlateauHeight { get; set; }


        public RoverFiles()
        {
            
        }

        public byte[]  ConvertToByteArray()
        {
            using var ms = new MemoryStream();
            FormFile.CopyTo(ms); 
            return ms.ToArray();
        }
    }
}
