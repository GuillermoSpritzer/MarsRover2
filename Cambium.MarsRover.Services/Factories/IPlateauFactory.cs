namespace Cambium.MarsRover.Domain
{
    public interface IPlateauFactory
    {
        public Plateau CreateRectangularPlateau(int y, int x);

    }
}