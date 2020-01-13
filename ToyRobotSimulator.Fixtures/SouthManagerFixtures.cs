using NUnit.Framework;
using System;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager;
using ToyRobotSimulator.ConsoleApp.Enums;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.Fixtures
{
    public class SouthManagerFixtures
    {
        [Test]
        public void CardinalDirection_ReadCardinalDirection_South()
        {
            //Arrange           
            ICardinalDirectionManager southFacingManager = new SouthManager();

            //Act
            CardinalDirection facing = southFacingManager.CardinalDirection;

            //Assert
            Assert.AreEqual(CardinalDirection.SOUTH, facing);
        }

        [Test]
        public void TryMoveAhead_FromNotBorderPosition_DecreaseY()
        {
            //Arrange
            var currentPosition = new Position(2, 2);
            ICardinalDirectionManager southFacingManager = new SouthManager();

            //Act
            Position finalPosition = southFacingManager.TryMoveAhead(currentPosition);

            //Assert
            Assert.AreEqual(2, finalPosition.X);
            Assert.AreEqual(1, finalPosition.Y);
        }

        [Test]
        public void TryMoveAhead_FromSouthestPosition_DontMove()
        {
            //Arrange
            var currentPosition = new Position(0, 0);
            ICardinalDirectionManager southFacingManager = new SouthManager();

            //Act
            Position finalPosition = southFacingManager.TryMoveAhead(currentPosition);

            //Assert
            Assert.AreEqual(0, finalPosition.X);
            Assert.AreEqual(0, finalPosition.Y);
        }

        [Test]
        public void TryMoveAhead_NullPosition_ThrowArgumentNullException()
        {
            //Arrange
            ICardinalDirectionManager southFacingManager = new SouthManager();

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => southFacingManager.TryMoveAhead(null));
        }

        [Test]
        public void TurnRight_FromSouth_ToWest()
        {
            //Arrange
            ICardinalDirectionManager southFacingManager = new SouthManager();

            //Act
            ICardinalDirectionManager rightFacing = southFacingManager.TurnRight();

            //Assert
            Assert.AreEqual(CardinalDirection.WEST, rightFacing.CardinalDirection);
        }

        [Test]
        public void TurnLeft_FromSouth_ToEast()
        {
            //Arrange
            ICardinalDirectionManager southFacingManager = new SouthManager();

            //Act
            ICardinalDirectionManager leftFacing = southFacingManager.TurnLeft();

            //Assert
            Assert.AreEqual(CardinalDirection.EAST, leftFacing.CardinalDirection);
        }
    }
}