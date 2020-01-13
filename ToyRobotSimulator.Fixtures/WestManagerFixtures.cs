using NUnit.Framework;
using System;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager;
using ToyRobotSimulator.ConsoleApp.Enums;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.Fixtures
{
    public class WestManagerFixtures
    {
        [Test]
        public void Facing_ReadFacing_WestFacing()
        {
            //Arrange           
            ICardinalDirectionManager westFacingManager = new WestManager();

            //Act
            CardinalDirection facing = westFacingManager.CardinalDirection;

            //Assert
            Assert.AreEqual(CardinalDirection.WEST, facing);
        }

        [Test]
        public void TryMoveAhead_FromNotBorderPosition_DecreaseX()
        {
            //Arrange
            var currentPosition = new Position(1, 1);
            ICardinalDirectionManager westFacingManager = new WestManager();

            //Act
            Position finalPosition = westFacingManager.TryMoveAhead(currentPosition);

            //Assert
            Assert.AreEqual(0, finalPosition.X);
            Assert.AreEqual(1, finalPosition.Y);
        }

        [Test]
        public void TryMoveAhead_FromWestestPosition_DontMove()
        {
            //Arrange
            var currentPosition = new Position(0, 0);
            ICardinalDirectionManager westFacingManager = new WestManager();

            //Act
            Position finalPosition = westFacingManager.TryMoveAhead(currentPosition);

            //Assert
            Assert.AreEqual(0, finalPosition.X);
            Assert.AreEqual(0, finalPosition.Y);
        }

        [Test]
        public void TryMoveAhead_NullPosition_ThrowArgumentNullException()
        {
            //Arrange
            ICardinalDirectionManager westFacingManager = new WestManager();

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => westFacingManager.TryMoveAhead(null));
        }

        [Test]
        public void TurnRight_FromWest_ToNorth()
        {
            //Arrange
            ICardinalDirectionManager westFacingManager = new WestManager();

            //Act
            ICardinalDirectionManager rightFacing = westFacingManager.TurnRight();

            //Assert
            Assert.AreEqual(CardinalDirection.NORTH, rightFacing.CardinalDirection);
        }

        [Test]
        public void TurnLeft_FromWest_ToSouth()
        {
            //Arrange
            ICardinalDirectionManager westFacingManager = new WestManager();

            //Act
            ICardinalDirectionManager leftFacing = westFacingManager.TurnLeft();

            //Assert
            Assert.AreEqual(CardinalDirection.SOUTH, leftFacing.CardinalDirection);
        }
    }
}