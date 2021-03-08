
using System.Collections.Generic;
using Cambium.MarsRover.Domain;

namespace Cambium.MarsRover.Services
{
    public interface INavigationService
    {
        public Rover Rover { get; set; }

        public Plateau Plateau { get; set; }
        public void Move();

        public Direction Rotate(string direction);

        public string ReceiveInstructions(string instructions);

        public string ReceiveMultipleInstructions(List<string> instructions);

        public void AssignPlateau(int width, int height);

        public void AssignRover(Rover rover);


    }
}