namespace Cambium.MarsRover.Domain
{
    public interface IRoverFactory
    {
        public Rover CreateMarsRover(int x, int y, Direction direction);

        public Rover CreateMarsRover(int x, int y, string direction);

    }
}