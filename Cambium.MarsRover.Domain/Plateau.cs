namespace Cambium.MarsRover.Domain
{
    public class Plateau
    {
        public int Height { get; set; }
        public int Width { get; set; }


        public Plateau(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}