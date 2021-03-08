using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cambium.MarsRover.Web.Exceptions
{
    public class InvalidFileException:Exception
    {

        public InvalidFileException() : base()
        {
        }

        public InvalidFileException(string message) : base(message)
        {
        }

        public InvalidFileException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
