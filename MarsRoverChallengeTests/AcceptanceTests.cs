using MarsRoverChallenge;
using NUnit.Framework;
using System;

namespace MarsRoverChallengeTests
{
    [TestFixture]
    public class AcceptanceTests
    {
        [Test]
        public void Turn90Right_Success()
        {
            //arrange
            Position position = new Position("12N");

            //act
            position.Turn90Right();

            //assert
            Assert.AreEqual(CardinalDirection.E, position.Direction);
        }

        [Test]
        public void Turn90Left_Success()
        {
            //arrange
            Position position = new Position("12N");

            //act
            position.Turn90Left();

            //assert
            Assert.AreEqual(CardinalDirection.W, position.Direction);
        }

        [Test]
        public void AdvanceForward_Success()
        {
            //arrange
            Position position = new Position("12N");

            //act
            position.AdvanceForward();

            //assert
            Assert.AreEqual(3, position.Y);
        }

        [Test]
        public void Move_Success()
        {
            //arrange
            Rover rover = new Rover("1 2 N");
            Plateau plateau = new Plateau("5 5");
            string commands = "LMLMLMLMM";

            //act
            rover.Move(plateau, commands);

            //assert
            Assert.AreEqual("1 3 N", rover.OutputLocation);
        }

        [Test]
        public void Move_Failure()
        {
            //arrange
            Rover rover = new Rover("1 5 N");
            Plateau plateau = new Plateau("5 5");
            string commands = "M";

            //act & assert
            var ex = Assert.Throws<Exception>(() => rover.Move(plateau, commands));
            Assert.AreEqual($"Rover can not move beyond plateau bounderies (0 , 0) and ({plateau.MaximumX} , {plateau.MaximumY})", ex.Message);
        }
    }
}