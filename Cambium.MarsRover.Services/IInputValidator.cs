namespace Cambium.MarsRover.Services
{
    public interface IInputValidator
    {
        public bool ValidateRoverInstructions(string instructions);
        public string ParseInstructions(string instructions);
        public string[] ParsePosition(string instructions);
    }
}