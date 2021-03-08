using System;
using System.Collections.Generic;
using System.Text;

namespace Cambium.MarsRover.Services.Exceptions
{
    public class RoverLeavesPlateuException:Exception
    {

        public RoverLeavesPlateuException() : base()
        {
        }

        public RoverLeavesPlateuException(string message) : base(message)
        {
        }

        public RoverLeavesPlateuException(string message, Exception inner) : base(message, inner)
        {
        }
    }

}
