using System;
using System.Runtime.ConstrainedExecution;
using Cambium.MarsRover.Domain;
using Cambium.MarsRover.Services.Exceptions;
using NUnit.Framework;

namespace Cambium.MarsRover.Services.Tests
{
    public class Tests
    {
        private IRoverFactory _roverFactory;
        private IPlateauFactory _plateauFactory;
        private INavigationService _movingService;
        private IInputValidator _inputValidator;

        [SetUp]
        public void Setup()
        {
            _inputValidator = new InputValidator(new InputConfiguration());
            _roverFactory = new RoverFactory();
            _plateauFactory = new PlateauFactory();
            _movingService = new NavigationService(_inputValidator, _roverFactory, _plateauFactory);
        }


        [Test]
        [TestCase(Direction.East, Direction.North)]
        [TestCase(Direction.North, Direction.West)]
        [TestCase(Direction.South, Direction.East)]
        [TestCase(Direction.West, Direction.South)]
        public void RotateRight(Direction expectedResult, Direction initialdirection)
        {
            var rover = _roverFactory.CreateMarsRover(1, 1, initialdirection);
            _movingService.AssignRover(rover);
            _movingService.Rotate("R");
            Assert.AreEqual(rover.Direction, expectedResult);
        }

        [Test]
        [TestCase(Direction.North, Direction.East)]
        [TestCase(Direction.West, Direction.North)]
        [TestCase(Direction.East, Direction.South)]
        [TestCase(Direction.South, Direction.West)]
        public void RotateLeft(Direction expectedResult, Direction initialdirection)
        {
            var rover = _roverFactory.CreateMarsRover(1, 1, initialdirection);
            _movingService.AssignRover(rover);
            _movingService.Rotate("L");
            Assert.AreEqual(rover.Direction, expectedResult);
        }

        [Test]
        [TestCase(1, 1, Direction.South, 1, 0, Direction.South)]
        [TestCase(1, 1, Direction.East, 2, 1, Direction.East)]
        [TestCase(1, 1, Direction.West, 0, 1, Direction.West)]
        [TestCase(1, 1, Direction.North, 1, 2, Direction.North)]
        public void TestMove(int initialx, int initialy, Direction initiald, int finalx, int finaly, Direction finald)
        {
            var rover = _roverFactory.CreateMarsRover(initialx, initialy, initiald);
            rover.Move();
            Assert.AreEqual(rover.X, finalx);
            Assert.AreEqual(rover.Y, finaly);
            Assert.AreEqual(rover.Direction, finald);
        }


        [Test]
        [TestCase("1 2 N|LMLMLMLMM", 1, 3, Direction.North)]
        [TestCase("1 2 N|LMLMLMLM", 1, 2, Direction.North)]
        [TestCase("1 2 N|LMLMLMLMRRRR", 1, 2, Direction.North)]
        [TestCase("3 3 E|MMRMMRMRRM", 5, 1, Direction.East)]
        public void TestPassInstructions(string instructions, int finalx, int finaly, Direction finald)
        {
            _movingService.AssignPlateau(5, 5);
            _movingService.RecieveInstructions(instructions);
            Assert.AreEqual(finalx, _movingService.Rover.X);
            Assert.AreEqual(finaly, _movingService.Rover.Y);
            Assert.AreEqual(finald, _movingService.Rover.Direction);
        }

        [Test]
        [TestCase(20, 20, Direction.East)]
        [TestCase(-1, 20, Direction.East)]
        [TestCase(20, 10, Direction.East)]
        [TestCase(2, -1, Direction.East)]
        public void TestPassPositionLargerThanPLateuThrowsException(int initialx, int initialy, Direction initiald)
        {
            try
            {
                _movingService.AssignPlateau(10, 10);
                _movingService.AssignRover(_roverFactory.CreateMarsRover(initialx, initialy, initiald));
            }
            catch (RoverLeavesPlateuException)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        [TestCase("1 2 N|LMLMLMLMMMMMMMMMMMMMMMMMMM")]
        [TestCase("1 2 N|LMLMLMRMMMMMMMMMMMMMMMMMMM")]

        public void TestPassRoverMovesLargerThanPLateuThrowsException(string instruction)
        {


                _movingService.AssignPlateau(5, 5);
                var ret = _movingService.RecieveInstructions(instruction);
                Assert.AreEqual("Instructions invalid Rover will Leave plateau", ret);

            
        }


    }
}