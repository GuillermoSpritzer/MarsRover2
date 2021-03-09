namespace Cambium.MarsRover.Services
{
    public class InputConfiguration:IInputConfiguration
    {
        public int LengthPosition { get; set; }
        public int MinLength { get; set; }
        public string MovingCharacters { get; set; }
        public string PositionCharacters { get; set; }
        public char Separator { get; set; }
        public InputConfiguration()
        {
            LengthPosition = 5;
            MinLength = 7;
            MovingCharacters = "RLM";
            PositionCharacters = "NSEW";
            Separator = '|';
        }

    }
}