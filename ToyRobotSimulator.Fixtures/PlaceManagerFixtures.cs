using NUnit.Framework;
using System;
using ToyRobotSimulator.ConsoleApp.BusinessLogic;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.Commands;

namespace ToyRobotSimulator.Fixtures
{
    public class PlaceManagerFixtures
    {
        [Test]
        public void PlaceRobotOnTable_ValidNorthPosition_CreateToyRobot()
        {
            //Arrange           
            string command = "PLACE 0,0,NORTH";
            IPlaceManager placeManager = new PlaceManager();

            //Act
            ToyRobot toyRobot = placeManager.PlaceRobotOnTable(command);

            //Assert
            Assert.NotNull(toyRobot);
        }

        [Test]
        public void PlaceRobotOnTable_ValidSouthPosition_CreateToyRobot()
        {
            //Arrange           
            string command = "PLACE 0,0,SOUTH";
            IPlaceManager placeManager = new PlaceManager();

            //Act
            ToyRobot toyRobot = placeManager.PlaceRobotOnTable(command);

            //Assert
            Assert.NotNull(toyRobot);
        }

        [Test]
        public void PlaceRobotOnTable_ValidWestPosition_CreateToyRobot()
        {
            //Arrange           
            string command = "PLACE 0,0,WEST";
            IPlaceManager placeManager = new PlaceManager();

            //Act
            ToyRobot toyRobot = placeManager.PlaceRobotOnTable(command);

            //Assert
            Assert.NotNull(toyRobot);
        }

        [Test]
        public void PlaceRobotOnTable_ValidEastPosition_CreateToyRobot()
        {
            //Arrange           
            string command = "PLACE 0,0,WEST";
            IPlaceManager placeManager = new PlaceManager();

            //Act
            ToyRobot toyRobot = placeManager.PlaceRobotOnTable(command);

            //Assert
            Assert.NotNull(toyRobot);
        }

        [Test]
        public void PlaceRobotOnTable_NotPlaceCommand_DontCreateToyRobot()
        {
            //Arrange           
            string command = "NOT A PLACE COMMAND";
            IPlaceManager placeManager = new PlaceManager();

            //Act and Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => placeManager.PlaceRobotOnTable(command));
            Assert.AreEqual("this is not a place command: NOT A PLACE COMMAND", exception.Message);
        }

        [Test]
        public void PlaceRobotOnTable_NoCommand_DontCreateToyRobot()
        {
            //Arrange           
            string command = null;
            IPlaceManager placeManager = new PlaceManager();

            //Act and Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => placeManager.PlaceRobotOnTable(command));
            Assert.AreEqual("Value cannot be null. (Parameter 'command')", exception.Message);
        }

        [Test]
        public void PlaceRobotOnTable_PlaceCommandWithExtraInfo_DontCreateToyRobot()
        {
            //Arrange           
            string command = "PLACE 0,0,NORTH extra info";
            IPlaceManager placeManager = new PlaceManager();

            //Act and Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => placeManager.PlaceRobotOnTable(command));
            Assert.AreEqual("invalid place command: PLACE 0,0,NORTH extra info", exception.Message);
        }

        [Test]
        public void PlaceRobotOnTable_PlaceCommandWithWrongNumberOfArguments_DontCreateToyRobot()
        {
            //Arrange           
            string command = "PLACE 0,0";
            IPlaceManager placeManager = new PlaceManager();

            //Act and Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => placeManager.PlaceRobotOnTable(command));
            Assert.AreEqual("invalid number of arguments for place command: 2", exception.Message);
        }

        [Test]
        public void PlaceRobotOnTable_PlaceCommandWithWrongXPositionArgument_DontCreateToyRobot()
        {
            //Arrange           
            string command = "PLACE One,0,NORTH";
            IPlaceManager placeManager = new PlaceManager();

            //Act and Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => placeManager.PlaceRobotOnTable(command));
            Assert.AreEqual("x is not a number: One", exception.Message);
        }

        [Test]
        public void PlaceRobotOnTable_PlaceCommandWithWrongYPositionArgument_DontCreateToyRobot()
        {
            //Arrange           
            string command = "PLACE 0,One,NORTH";
            IPlaceManager placeManager = new PlaceManager();

            //Act and Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => placeManager.PlaceRobotOnTable(command));
            Assert.AreEqual("y is not a number: One", exception.Message);
        }

        [Test]
        public void PlaceRobotOnTable_PlaceCommandWithWrongCardinalDirection_DontCreateToyRobot()
        {
            //Arrange           
            string command = "PLACE 0,1,NORD";
            IPlaceManager placeManager = new PlaceManager();

            //Act and Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => placeManager.PlaceRobotOnTable(command));
            Assert.AreEqual("invalid value for cardinal position: NORD", exception.Message);
        }

        [Test]
        public void PlaceRobotOnTable_PlaceCommandWithXPositionGreaterThanMax_DontCreateToyRobot()
        {
            //Arrange           
            string command = "PLACE 6,0,NORTH";
            IPlaceManager placeManager = new PlaceManager();

            //Act and Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => placeManager.PlaceRobotOnTable(command));
            Assert.AreEqual("x value is out of range: 6; SquareTabletopSize: 5", exception.Message);
        }

        [Test]
        public void PlaceRobotOnTable_PlaceCommandWithXPositionLowerThanMin_DontCreateToyRobot()
        {
            //Arrange           
            string command = "PLACE -1,0,NORTH";
            IPlaceManager placeManager = new PlaceManager();

            //Act and Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => placeManager.PlaceRobotOnTable(command));
            Assert.AreEqual("x value is out of range: -1; SquareTabletopSize: 5", exception.Message);
        }

        [Test]
        public void PlaceRobotOnTable_PlaceCommandWithYPositionGreaterThanMax_DontCreateToyRobot()
        {
            //Arrange           
            string command = "PLACE 0,7,NORTH";
            IPlaceManager placeManager = new PlaceManager();

            //Act and Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => placeManager.PlaceRobotOnTable(command));
            Assert.AreEqual("y value is out of range: 7; SquareTabletopSize: 5", exception.Message);
        }

        [Test]
        public void PlaceRobotOnTable_PlaceCommandWithYPositionLowerThanMin_DontCreateToyRobot()
        {
            //Arrange           
            string command = "PLACE 0,-2,NORTH";
            IPlaceManager placeManager = new PlaceManager();

            //Act and Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => placeManager.PlaceRobotOnTable(command));
            Assert.AreEqual("y value is out of range: -2; SquareTabletopSize: 5", exception.Message);
        }

        [Test]
        public void PlaceRobotOnTable_PlaceWithoutArguments_DontCreateToyRobot()
        {
            //Arrange           
            string command = "PLACE";
            IPlaceManager placeManager = new PlaceManager();

            //Act and Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => placeManager.PlaceRobotOnTable(command));
            Assert.AreEqual("invalid place command: PLACE", exception.Message);
        }
    }
}