using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cambium.MarsRover.Web.Exceptions;
using Cambium.MarsRover.Web.Helpers;
using CsvHelper;

namespace Cambium.MarsRover.Web
{
    public class FileReaderHelper: IFileReaderHelper
    {
        public List<string> ReadInstructionsFile(byte[] fileData, string fileName)
        {
            try
            {

                var records = new List<string>();
                using (var ms = new MemoryStream(fileData))
                {
                    using (var reader = new StreamReader(ms, true))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Read();
                        csv.ReadHeader();
                        while (csv.Read())
                        {
                            records.Add(csv.GetField("Instruction"));
                        }
                        return records;
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidFileException("File is invalid");
            }
        }
    }

}

