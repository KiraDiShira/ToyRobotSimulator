using Moq;
using NUnit.Framework;
using System;
using ToyRobotSimulator.ConsoleApp.ApplicationLogic;
using ToyRobotSimulator.ConsoleApp.BusinessLogic;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.Commands;
using ToyRobotSimulator.ConsoleApp.Enums;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.Fixtures
{
    public class SimulatorFixtures
    {
        [Test]
        public void Run_NoCommands_ThrowException()
        {
            //Arrange
            string[] commands = null;

            var placeManagerMock = new Mock<IPlaceManager>();
            var errorReporterMock = new Mock<IErrorReporter>();
            var toyRobotSimulator =
                            new Simulator(placeManagerMock.Object, errorReporterMock.Object);
            //Act and Assert
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => toyRobotSimulator.Run(commands));
            Assert.AreEqual("Value cannot be null. (Parameter 'commands')", exception.Message);
        }

        [Test]
        public void Run_PlaceCommand_PutRobotOnTable()
        {
            //Arrange
            string[] commands =
            new[]{
            "PLACE 0,0,NORTH"
            };

            ToyRobot toyRobotMock = new ToyRobot(new Position(0, 0), new NorthManager(), new ReportManager());
            var placeManagerMock = new Mock<IPlaceManager>();
            placeManagerMock.Setup(placeManager => placeManager.PlaceRobotOnTable("PLACE 0,0,NORTH")).Returns(toyRobotMock);
            var errorReporterMock = new Mock<IErrorReporter>();
            var toyRobotSimulator =
                new Simulator(placeManagerMock.Object, errorReporterMock.Object);
            //Act 
            ToyRobotState toyRobotState = toyRobotSimulator.Run(commands);

            //Assert
            Assert.AreEqual(0, toyRobotState.X);
            Assert.AreEqual(0, toyRobotState.Y);
            Assert.AreEqual(CardinalDirection.NORTH, toyRobotState.CardinalDirection);
        }

        [Test]
        public void Run_InvalidPlaceCommand_ReportErrorAndSkipThisInvalidCommad()
        {
            //Arrange
            string[] commands =
            new[]{
            "PLACE WRONG"
            };

            var placeManagerMock = new Mock<IPlaceManager>();
            placeManagerMock.Setup(placeManager => placeManager.PlaceRobotOnTable("PLACE WRONG")).Throws<InvalidOperationException>();
            var errorReporterMock = new Mock<IErrorReporter>();
            var toyRobotSimulator =
                            new Simulator(placeManagerMock.Object, errorReporterMock.Object);
            //Act 
            ToyRobotState toyRobotState = toyRobotSimulator.Run(commands);

            //Assert
            errorReporterMock.Verify(errorReporter => errorReporter.Send(It.IsAny<Exception>()), Times.Once);
            Assert.IsNull(toyRobotState);
        }


        [Test]
        public void Run_MoveCommandAsTheFirstOne_DoNothing()
        {
            //Arrange
            string[] commands =
            new[]{
            "MOVE"
            };

            var placeManagerMock = new Mock<IPlaceManager>();
            var errorReporterMock = new Mock<IErrorReporter>();
            var toyRobotSimulator =
                            new Simulator(placeManagerMock.Object, errorReporterMock.Object);
            //Act 
            ToyRobotState toyRobotState = toyRobotSimulator.Run(commands);

            //Assert
            Assert.IsNull(toyRobotState);
        }

        [Test]
        public void Run_InvalidMoveCommand_ReportErrorAndSkipThisInvalidCommad()
        {
            //Arrange
            string[] commands =
            new[]{
            "MOVE WRONG"
            };

            var placeManagerMock = new Mock<IPlaceManager>();
            var errorReporterMock = new Mock<IErrorReporter>();
            var toyRobotSimulator =
                new Simulator(placeManagerMock.Object, errorReporterMock.Object);
            //Act 
            ToyRobotState toyRobotState = toyRobotSimulator.Run(commands);

            //Assert
            errorReporterMock.Verify(errorReporter => errorReporter.Send(It.IsAny<Exception>()), Times.Once);
            Assert.IsNull(toyRobotState);
        }

        [Test]
        public void Run_LeftCommandAsTheFirstOne_DoNothing()
        {
            //Arrange
            string[] commands =
            new[]{
            "LEFT"
            };

            var placeManagerMock = new Mock<IPlaceManager>();
            var errorReporterMock = new Mock<IErrorReporter>();
            var toyRobotSimulator =
                            new Simulator(placeManagerMock.Object, errorReporterMock.Object);
            //Act 
            ToyRobotState toyRobotState = toyRobotSimulator.Run(commands);

            //Assert
            Assert.IsNull(toyRobotState);
        }

        [Test]
        public void Run_InvalidLeftCommand_ReportErrorAndSkipThisInvalidCommad()
        {
            //Arrange
            string[] commands =
            new[]{
            "LEFT WRONG"
            };

            var placeManagerMock = new Mock<IPlaceManager>();
            var errorReporterMock = new Mock<IErrorReporter>();
            var toyRobotSimulator =
                 new Simulator(placeManagerMock.Object, errorReporterMock.Object);
            //Act 
            ToyRobotState toyRobotState = toyRobotSimulator.Run(commands);

            //Assert
            errorReporterMock.Verify(errorReporter => errorReporter.Send(It.IsAny<Exception>()), Times.Once);
            Assert.IsNull(toyRobotState);
        }

        [Test]
        public void Run_RightCommandAsTheFirstOne_DoNothing()
        {
            //Arrange
            string[] commands =
            new[]{
            "RIGHT"
            };

            var placeManagerMock = new Mock<IPlaceManager>();
            var errorReporterMock = new Mock<IErrorReporter>();
            var toyRobotSimulator =
                new Simulator(placeManagerMock.Object, errorReporterMock.Object);
            //Act 
            ToyRobotState toyRobotState = toyRobotSimulator.Run(commands);

            //Assert
            Assert.IsNull(toyRobotState);
        }

        [Test]
        public void Run_InvalidRightCommand_ReportErrorAndSkipThisInvalidCommad()
        {
            //Arrange
            string[] commands =
            new[]{
            "RIGHT WRONG"
            };

            var placeManagerMock = new Mock<IPlaceManager>();
            var errorReporterMock = new Mock<IErrorReporter>();
            var toyRobotSimulator =
                            new Simulator(placeManagerMock.Object, errorReporterMock.Object);
            //Act 
            ToyRobotState toyRobotState = toyRobotSimulator.Run(commands);

            //Assert
            errorReporterMock.Verify(errorReporter => errorReporter.Send(It.IsAny<Exception>()), Times.Once);
            Assert.IsNull(toyRobotState);
        }

        [Test]
        public void Run_ReportCommandAsTheFirstOne_DoNothing()
        {
            //Arrange
            string[] commands =
            new[]{
            "REPORT"
            };

            var placeManagerMock = new Mock<IPlaceManager>();
            var errorReporterMock = new Mock<IErrorReporter>();
            var toyRobotSimulator =
                            new Simulator(placeManagerMock.Object, errorReporterMock.Object);
            //Act 
            ToyRobotState toyRobotState = toyRobotSimulator.Run(commands);

            //Assert
            Assert.IsNull(toyRobotState);
        }

        [Test]
        public void Run_InvalidReportCommand_ReportErrorAndSkipThisInvalidCommad()
        {
            //Arrange
            string[] commands =
            new[]{
            "REPORT WRONG"
            };

            var placeManagerMock = new Mock<IPlaceManager>();
            var errorReporterMock = new Mock<IErrorReporter>();

            var toyRobotSimulator =
                            new Simulator(placeManagerMock.Object, errorReporterMock.Object);
            //Act 
            ToyRobotState toyRobotState = toyRobotSimulator.Run(commands);

            //Assert
            errorReporterMock.Verify(errorReporter => errorReporter.Send(It.IsAny<Exception>()), Times.Once);
            Assert.IsNull(toyRobotState);
        }

        [Test]
        public void Run_InvalidCommand_ReportErrorAndSkipThisInvalidCommad()
        {
            //Arrange
            string[] commands =
            new[]{
            "THIS IS AN INVALID COMMAND"
            };

            var placeManagerMock = new Mock<IPlaceManager>();
            var errorReporterMock = new Mock<IErrorReporter>();

            var toyRobotSimulator =
                            new Simulator(placeManagerMock.Object, errorReporterMock.Object);
            //Act 
            ToyRobotState toyRobotState = toyRobotSimulator.Run(commands);

            //Assert
            errorReporterMock.Verify(errorReporter => errorReporter.Send(It.IsAny<Exception>()), Times.Once);
            Assert.IsNull(toyRobotState);
        }

        [Test]
        public void Run_FromOrigin_ToNorthEast()
        {
            //Arrange
            string[] commands =
            new[]{
            "MOVE",
            "LEFT",
            "RIGHT",
            "MOVE",
            "PLACE 0,0,SOUTH",
            "MOVE",
            "MOVE",
            "LEFT",
            "MOVE",
            "MOVE",
            "MOVE",
            "MOVE",
            "MOVE",
            "MOVE",
            "LEFT",
            "MOVE",
            "MOVE",
            "MOVE",
            "MOVE"
            };

            var placeManagerMock = new Mock<IPlaceManager>();
            placeManagerMock.Setup(placeManager => placeManager.PlaceRobotOnTable("PLACE 0,0,SOUTH")).Returns(new ToyRobot(new Position(0, 0), new SouthManager(), new ReportManager()));

            var errorReporterMock = new Mock<IErrorReporter>();

            var toyRobotSimulator =
                            new Simulator(placeManagerMock.Object, errorReporterMock.Object);
            //Act 
            ToyRobotState toyRobotState = toyRobotSimulator.Run(commands);

            //Assert            
            Assert.AreEqual(4, toyRobotState.X);
            Assert.AreEqual(4, toyRobotState.Y);
            Assert.AreEqual(CardinalDirection.NORTH, toyRobotState.CardinalDirection);
        }

        [Test]
        public void Run_TwoPlacesCommand_ValidCommands()
        {
            //Arrange
            string[] commands =
            new[]{
            "MOVE",
            "LEFT",
            "RIGHT",
            "MOVE",
            "PLACE 0,0,SOUTH",
            "MOVE",
            "MOVE",
            "LEFT",
            "MOVE",
            "MOVE",
            "MOVE",
            "MOVE",
            "MOVE",
            "MOVE",
            "LEFT",
            "MOVE",
            "MOVE",
            "MOVE",
            "MOVE",
            "PLACE 2,3,EAST",
            };

            var placeManagerMock = new Mock<IPlaceManager>();
            placeManagerMock.SetupSequence(placeManager => placeManager.PlaceRobotOnTable(It.IsAny<String>()))
                .Returns(new ToyRobot(new Position(0, 0), new SouthManager(), new ReportManager()))
                .Returns(new ToyRobot(new Position(2, 3), new EastManager(), new ReportManager()))
                ;

            var errorReporterMock = new Mock<IErrorReporter>();


            var toyRobotSimulator =
                new Simulator(placeManagerMock.Object, errorReporterMock.Object);

            //Act 
            ToyRobotState toyRobotState = toyRobotSimulator.Run(commands);

            //Assert            
            Assert.AreEqual(2, toyRobotState.X);
            Assert.AreEqual(3, toyRobotState.Y);
            Assert.AreEqual(CardinalDirection.EAST, toyRobotState.CardinalDirection);
        }

    }
}
