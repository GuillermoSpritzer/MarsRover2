using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cambium.MarsRover.Web.Model
{
    public class RoverInstructions
    {
        public int PlateauWidth { get; set; }
        public int PlateauHeight { get; set; }
        public string Instructions { get; set; }


        public RoverInstructions()
        {

        }

        public RoverInstructions(int plateauWidth, int plateauHeight, string instructions)
        {
            PlateauWidth = plateauWidth;
            PlateauHeight = plateauHeight;
            Instructions = instructions;
        }
    }

}
