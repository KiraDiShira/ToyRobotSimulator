using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager;
using ToyRobotSimulator.ConsoleApp.Enums;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.Fixtures
{
    public class NorthManagerFixtures
    {
        [Test]
        public void Facing_ReadFacing_NorthFacing()
        {
            //Arrange           
            ICardinalDirectionManager northFacingManager = new NorthManager();

            //Act
            CardinalDirection facing = northFacingManager.CardinalDirection;

            //Assert
            Assert.AreEqual(CardinalDirection.NORTH, facing);
        }

        [Test]
        public void TryMoveAhead_FromNotBorderPosition_IncreaseY()
        {
            //Arrange
            var currentPosition = new Position(1, 1);
            ICardinalDirectionManager northFacingManager = new NorthManager();

            //Act
            Position finalPosition = northFacingManager.TryMoveAhead(currentPosition);

            //Assert
            Assert.AreEqual(1, finalPosition.X);
            Assert.AreEqual(2, finalPosition.Y);
        }

        [Test]
        public void TryMoveAhead_FromNorthestPosition_DontMove()
        {
            //Arrange
            var currentPosition = new Position(0, 4);
            ICardinalDirectionManager northFacingManager = new NorthManager();

            //Act
            Position finalPosition = northFacingManager.TryMoveAhead(currentPosition);

            //Assert
            Assert.AreEqual(0, finalPosition.X);
            Assert.AreEqual(4, finalPosition.Y);
        }

        [Test]
        public void TryMoveAhead_NullPosition_ThrowArgumentNullException()
        {
            //Arrange
            ICardinalDirectionManager northFacingManager = new NorthManager();

            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => northFacingManager.TryMoveAhead(null));
        }

        [Test]
        public void TurnRight_FromNorth_ToEast()
        {
            //Arrange
            ICardinalDirectionManager northFacingManager = new NorthManager();

            //Act
            ICardinalDirectionManager rightFacing = northFacingManager.TurnRight();

            //Assert
            Assert.AreEqual(CardinalDirection.EAST, rightFacing.CardinalDirection);
        }

        [Test]
        public void TurnLeft_FromNorth_ToWest()
        {
            //Arrange
            ICardinalDirectionManager northFacingManager = new NorthManager();

            //Act
            ICardinalDirectionManager leftFacing = northFacingManager.TurnLeft();

            //Assert
            Assert.AreEqual(CardinalDirection.WEST, leftFacing.CardinalDirection);
        }
    }
}