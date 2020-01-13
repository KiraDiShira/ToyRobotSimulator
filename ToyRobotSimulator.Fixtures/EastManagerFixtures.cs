using NUnit.Framework;
using System;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager;
using ToyRobotSimulator.ConsoleApp.Enums;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.Fixtures
{
    public class EastFacingManagerFixtures
    {
        [Test]
        public void CardinalDirection_ReadCardinalDirection_East()
        {
            //Arrange           
            ICardinalDirectionManager cardinalDirectionManager = new EastManager();

            //Act
            CardinalDirection cardinalDirection = cardinalDirectionManager.CardinalDirection;

            //Assert
            Assert.AreEqual(CardinalDirection.EAST, cardinalDirection);
        }

        [Test]
        public void TryMoveAhead_FromNotBorderPosition_IncreaseX()
        {
            //Arrange
            var currentPosition = new Position(1, 1);
            ICardinalDirectionManager cardinalDirectionManager = new EastManager();

            //Act
            Position finalPosition = cardinalDirectionManager.TryMoveAhead(currentPosition);

            //Assert
            Assert.AreEqual(2, finalPosition.X);
            Assert.AreEqual(1, finalPosition.Y);
        }

        [Test]
        public void TryMoveAhead_FromEastestPosition_DontMove()
        {
            //Arrange
            var currentPosition = new Position(4, 0);
            ICardinalDirectionManager cardinalDirectionManager = new EastManager();

            //Act
            Position finalPosition = cardinalDirectionManager.TryMoveAhead(currentPosition);

            //Assert
            Assert.AreEqual(4, finalPosition.X);
            Assert.AreEqual(0, finalPosition.Y);
        }

        [Test]
        public void TryMoveAhead_NullPosition_ThrowArgumentNullException()
        {
            //Arrange
            ICardinalDirectionManager cardinalDirectionManager = new EastManager();

            //Act and Assert
            var exception = Assert.Throws<ArgumentNullException>(() => cardinalDirectionManager.TryMoveAhead(null));
            Assert.AreEqual("Value cannot be null. (Parameter 'position')", exception.Message);
        }

        [Test]
        public void TurnRight_FromEast_ToSouth()
        {
            //Arrange
            ICardinalDirectionManager cardinalDirectionManager = new EastManager();

            //Act
            ICardinalDirectionManager rightFacing = cardinalDirectionManager.TurnRight();

            //Assert
            Assert.AreEqual(CardinalDirection.SOUTH, rightFacing.CardinalDirection);
        }

        [Test]
        public void TurnLeft_FromEast_ToNorth()
        {
            //Arrange
            ICardinalDirectionManager cardinalDirectionManager = new EastManager();

            //Act
            ICardinalDirectionManager leftFacing = cardinalDirectionManager.TurnLeft();

            //Assert
            Assert.AreEqual(CardinalDirection.NORTH, leftFacing.CardinalDirection);
        }
    }
}