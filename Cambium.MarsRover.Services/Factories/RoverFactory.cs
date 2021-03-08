namespace Cambium.MarsRover.Domain
{
    public class RoverFactory : IRoverFactory
    {
        public Rover CreateMarsRover(int x, int y, Direction direction)
        {
            return new Rover(x, y, direction);
        }

        public Rover CreateMarsRover(int x, int y, string direction)
        {
            Direction dir = Direction.East;
            if (direction == "N")
                dir = Direction.North;
            if (direction == "S")
                dir = Direction.South;
            if (direction == "E")
                dir = Direction.East;
            if (direction == "S")
                dir = Direction.South;

            return new Rover(x, y, dir);
        }
    }
}