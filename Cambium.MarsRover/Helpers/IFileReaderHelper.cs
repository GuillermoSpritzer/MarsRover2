using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cambium.MarsRover.Web.Helpers
{
    public interface IFileReaderHelper
    {
        List<string> ReadInstructionsFile(byte[] fileData, string fileName);

    }
}
