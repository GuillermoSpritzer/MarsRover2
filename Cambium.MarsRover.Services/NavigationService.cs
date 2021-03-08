using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Transactions;
using Cambium.MarsRover.Domain;
using Cambium.MarsRover.Services.Exceptions;

namespace Cambium.MarsRover.Services
{
    public class NavigationService : INavigationService
    {
        public Rover Rover { get; set; }

        public Plateau Plateau { get; set; }

        private readonly IInputValidator _inputValidator;
        private readonly IRoverFactory _roverFactory;
        private readonly IPlateauFactory _plateauFactory;

        public NavigationService(IInputValidator inputValidator, IRoverFactory roverFactory, IPlateauFactory plateauFactory)
        {
            _inputValidator = inputValidator;
            _roverFactory = roverFactory;
            _plateauFactory = plateauFactory;
        }
       
        public void Move()
        {
            using (var transaction = new TransactionScope())
            {
                Rover.Move();
                if (Rover.X > Plateau.Width || Rover.Y > Plateau.Height || Rover.X < 0 || Rover.Y < 0)
                    throw new RoverLeavesPlateuException("Rover will leave plateau with this instructions");
                transaction.Complete();
            }
        }

        public Direction Rotate(string direction)
        {
           return  Rover.Rotate(direction);
        }

        public string RecieveInstructions(string instructions)
        {
            try
            { if (!_inputValidator.ValidateRoverInstructions(instructions))
                return "Instructions are not Valid";

                var instructionsParsed = _inputValidator.ParseInstructions(instructions);
                var position = _inputValidator.ParsePosition(instructions);

                Rover = _roverFactory.CreateMarsRover(int.Parse(position[0]), int.Parse(position[1]), position[2]);
                AssignRover(Rover);
                for (int i = 0; i < instructionsParsed.Length; i++)
                {
                    if (instructionsParsed[i] == 'M')
                        Move();
                    else
                    {
                        Rotate(instructionsParsed[i].ToString());
                    }
                }
                return string.Format("Mars Rover with instrunctions {0} succsfully reached final destination {1}", instructions ,Rover);
            }
            catch (RoverLeavesPlateuException)
            {
                return "Instructions "+ instructions + "invalid Rover will Leave plateau";
            }
        }


        public string RecieveMultipleInstrucitons(List<string> instructions)
        {
            var stringBuilder = new StringBuilder();
          //  stringBuilder.AppendLine(string.Format("for Plateau ( {0} , {1} )   File: {2} ", PlateauHeight, PlateauWidth, FileName));
            foreach (var inst in instructions)
            {
                stringBuilder.AppendLine("--> " + RecieveInstructions(inst));
            }

            return stringBuilder.ToString();

        }


        public void AssignPlateau(int width, int height)
        {
            Plateau = _plateauFactory.CreateRectangularPlateau(width,height);
        }

        public void AssignRover(Rover rover)
        {
            if (rover.X > Plateau.Width || rover.Y > Plateau.Height || rover.X < 0 || rover.Y < 0)
                throw new RoverLeavesPlateuException("Rover will leave plateau with this instructions");
            Rover = rover;
        }
    }
}
