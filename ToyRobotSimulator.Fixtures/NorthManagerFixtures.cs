using NUnit.Framework;
using System;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager;
using ToyRobotSimulator.ConsoleApp.Enums;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.Fixtures
{
    public class NorthManagerFixtures
    {
        [Test]
        public void CardinalDirection_ReadCardinalDirection_North()
        {
            //Arrange           
            ICardinalDirectionManager cardinalDirectionManager = new NorthManager();

            //Act
            CardinalDirection facing = cardinalDirectionManager.CardinalDirection;

            //Assert
            Assert.AreEqual(CardinalDirection.NORTH, facing);
        }

        [Test]
        public void TryMoveAhead_FromNotBorderPosition_IncreaseY()
        {
            //Arrange
            var currentPosition = new Position(1, 1);
            ICardinalDirectionManager cardinalDirectionManager = new NorthManager();

            //Act
            Position finalPosition = cardinalDirectionManager.TryMoveAhead(currentPosition);

            //Assert
            Assert.AreEqual(1, finalPosition.X);
            Assert.AreEqual(2, finalPosition.Y);
        }

        [Test]
        public void TryMoveAhead_FromNorthestPosition_DontMove()
        {
            //Arrange
            var currentPosition = new Position(0, 4);
            ICardinalDirectionManager cardinalDirectionManager = new NorthManager();

            //Act
            Position finalPosition = cardinalDirectionManager.TryMoveAhead(currentPosition);

            //Assert
            Assert.AreEqual(0, finalPosition.X);
            Assert.AreEqual(4, finalPosition.Y);
        }

        [Test]
        public void TryMoveAhead_NullPosition_ThrowArgumentNullException()
        {
            //Arrange
            ICardinalDirectionManager cardinalDirectionManager = new NorthManager();

            //Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => cardinalDirectionManager.TryMoveAhead(null));
            Assert.AreEqual("Value cannot be null. (Parameter 'position')", exception.Message);
        }

        [Test]
        public void TurnRight_FromNorth_ToEast()
        {
            //Arrange
            ICardinalDirectionManager cardinalDirectionManager = new NorthManager();

            //Act
            ICardinalDirectionManager rightFacing = cardinalDirectionManager.TurnRight();

            //Assert
            Assert.AreEqual(CardinalDirection.EAST, rightFacing.CardinalDirection);
        }

        [Test]
        public void TurnLeft_FromNorth_ToWest()
        {
            //Arrange
            ICardinalDirectionManager cardinalDirectionManager = new NorthManager();

            //Act
            ICardinalDirectionManager leftFacing = cardinalDirectionManager.TurnLeft();

            //Assert
            Assert.AreEqual(CardinalDirection.WEST, leftFacing.CardinalDirection);
        }
    }
}