namespace Cambium.MarsRover.Domain
{
    public class PlateauFactory : IPlateauFactory
    {
        public Plateau CreateRectangularPlateau(int height, int width)
        {
            return new Plateau(height, width);
        }
    }
}