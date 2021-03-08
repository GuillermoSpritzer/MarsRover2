using System;
using System.Security.Cryptography.X509Certificates;

namespace Cambium.MarsRover.Services
{
    public class InputValidator : IInputValidator
    {


        private readonly IInputConfiguration _config;

        public InputValidator(IInputConfiguration config)
        {
            _config = config;
        }

        public bool ValidateRoverInstructions(string instructions)
        {
            if (instructions.Length < _config.MinLength || !instructions.Contains('|'))
                return false;
            var instructionsArray = instructions.Split('|');
            if (instructionsArray[0].Length < _config.LengthPosition)
                return false;
            foreach (var ch in instructionsArray[1])
            {
                if (!_config.MovingCharacters.Contains(ch))
                {
                    return false;
                }
            }

            var arr = instructionsArray[0].Split(' ');
            int parout = 0;
            if (!int.TryParse(arr[0], out parout))
                return false;
            if (!int.TryParse(arr[1], out parout))
                return false;
            if (arr[2].Length > 1)
                return false;
            if (!_config.PositionCharacters.Contains(arr[2]))
                return false;


            return true;
        }

        public string ParseInstructions(string instructions)
        {
             var instructionsArray = instructions.Split('|');
             return instructionsArray[1];
        }

        public string[] ParsePosition(string instructions)
        {
            var instructionsArray = instructions.Split('|');
            var ret = instructionsArray[0].Split(" ");
            return ret;
        }
    }
}