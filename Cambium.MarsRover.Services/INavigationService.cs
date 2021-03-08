
using Cambium.MarsRover.Domain;

namespace Cambium.MarsRover.Services
{
    public interface INavigationService
    {
        public Rover Rover { get; set; }

        public Plateau Plateau { get; set; }
        public void Move();

        public Direction Rotate(string direction);

        public string RecieveInstructions(string instructions);


        public void AssignPlateau(int width, int height);

        public void AssignRover(Rover rover);


    }
}