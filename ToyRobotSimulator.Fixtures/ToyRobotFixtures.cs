using Moq;
using NUnit.Framework;
using ToyRobotSimulator.ConsoleApp.BusinessLogic;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.Commands;
using ToyRobotSimulator.ConsoleApp.Enums;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.Fixtures
{
    public class ToyRobotFixtures
    {
        [Test]
        public void Move_ToNorth_IncreaseYPosition()
        {
            //Arrange 
            var currentPosition = new Position(0, 0);
            var facingManagerMock = new Mock<ICardinalDirectionManager>();
            facingManagerMock.Setup(facingManager => facingManager.TryMoveAhead(currentPosition)).Returns(new Position(0, 1));
            var toyRobotManager = new ToyRobot(currentPosition, facingManagerMock.Object, new ReportManager());

            //Act
            Position finalPosition = toyRobotManager.Move();

            //Assert
            Assert.AreEqual(0, finalPosition.X);
            Assert.AreEqual(1, finalPosition.Y);
        }

        [Test]
        public void Right_FromNorth_ToEast()
        {
            //Arrange 
            var currentPosition = new Position(0, 0);
            var facingManagerMock = new Mock<ICardinalDirectionManager>();
            facingManagerMock.Setup(facingManager => facingManager.TurnRight()).Returns(new EastManager());
            var toyRobotManager = new ToyRobot(currentPosition, facingManagerMock.Object, new ReportManager());

            //Act
            CardinalDirection finalFacing = toyRobotManager.Right();

            //Assert
            Assert.AreEqual(CardinalDirection.EAST, finalFacing);
        }

        [Test]
        public void Left_FromNorth_ToWest()
        {
            //Arrange 
            var currentPosition = new Position(0, 0);
            var facingManagerMock = new Mock<ICardinalDirectionManager>();
            facingManagerMock.Setup(facingManager => facingManager.TurnLeft()).Returns(new WestManager());
            var toyRobotManager = new ToyRobot(currentPosition, facingManagerMock.Object, new ReportManager());

            //Act
            CardinalDirection finalFacing = toyRobotManager.Left();

            //Assert
            Assert.AreEqual(CardinalDirection.WEST, finalFacing);
        }

        [Test]
        public void Report_PrintPositionAndDirection_CheckConsoleWrapperIsCalled()
        {
            //Arrange 
            var currentPosition = new Position(0, 0);
            ICardinalDirectionManager facingManager = new NorthManager();
            var reportManagerMock = new Mock<IReportManager>();
            reportManagerMock.Setup(reportManager => reportManager.Report(It.IsAny<ToyRobotState>()));

            var toyRobotManager = new ToyRobot(currentPosition, facingManager, reportManagerMock.Object);

            //Act
            toyRobotManager.Report();

            //Assert
            reportManagerMock.Verify(reportManager => reportManager.Report(It.IsAny<ToyRobotState>()), Times.Once());
        }

        [Test]
        public void GetToyRobotState_ReadState_CorrectValues()
        {
            //Arrange 
            var currentPosition = new Position(1, 2);
            ICardinalDirectionManager cardinalDirectionManager = new NorthManager();
            var toyRobotManager = new ToyRobot(currentPosition, cardinalDirectionManager, new ReportManager());

            //Act
            ToyRobotState toyRobotState = toyRobotManager.GetState();

            //Assert
            Assert.AreEqual(1, toyRobotState.X);
            Assert.AreEqual(2, toyRobotState.Y);
            Assert.AreEqual(CardinalDirection.NORTH, toyRobotState.CardinalDirection);
        }
    }
}
