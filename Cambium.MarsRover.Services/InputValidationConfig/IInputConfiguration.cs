using System;

namespace Cambium.MarsRover.Services
{
    public interface IInputConfiguration
    {
        public int LengthPosition { get; set; }
        public int MinLength { get; set; }
        public string MovingCharacters { get; set; }
        public string PositionCharacters { get; set; }
        public string PositionExample { get; set; }
        public char Separator { get; set; }
    }
}