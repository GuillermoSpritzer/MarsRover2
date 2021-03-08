using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Cambium.MarsRover.Services.Tests
{
    public class InputValidatorTest
    {
        public InputValidator _InputValidator;

        [SetUp]
        public void Setup()
        {
            _InputValidator = new InputValidator(new InputConfiguration());
        }


        [Test]
        [TestCase("1 2 N|LMLMLMLMM", true)]
        [TestCase("1 22 N|LMLMLMLMM", true)]
        [TestCase("33 5 N|LMLMLMLMM", true)]
        [TestCase("3 3 E|MMRMMRMRRM", true)]
        [TestCase("1 N N|LMLMLMLMM", false)]
        [TestCase("1 N NcbcbLMLMLMLMM", false)]
        [TestCase("1 2 N22|LMLMLMLMM", false)]
        [TestCase("1 N N|LMLMLMLMM", false)]
        [TestCase("1 N N|LMLMLMLPMM", false)]
        [TestCase("1 N N|LMLMLMLMM", false)]
        [TestCase("1 N  N|LMLMLMLMM", false)]
        [TestCase(" 1 N N|LMLMLMLMM", false)]
        public void testInputForMArsRover(string input, bool expectedResult)
        {
           var isValid=  _InputValidator.ValidateRoverInstructions(input);

           Assert.AreEqual(expectedResult,isValid);
        }
    }
}
