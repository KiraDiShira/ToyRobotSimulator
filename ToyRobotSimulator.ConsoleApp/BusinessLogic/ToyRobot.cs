using ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.Commands;
using ToyRobotSimulator.ConsoleApp.Enums;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic
{
    public class ToyRobot
    {
        private Position _position;
        private ICardinalDirectionManager _cardinalDirectionManager;
        private readonly IReportManager _reportManager;

        public ToyRobot(Position position, ICardinalDirectionManager cardinalDirectionManager, IReportManager reportManager)
        {
            _position = position;
            _cardinalDirectionManager = cardinalDirectionManager;
            _reportManager = reportManager;
        }

        public Position Move()
        {
            _position = _cardinalDirectionManager.TryMoveAhead(_position);
            return _position;
        }

        public CardinalDirection Right()
        {
            _cardinalDirectionManager = _cardinalDirectionManager.TurnRight();
            return _cardinalDirectionManager.CardinalDirection;
        }

        public CardinalDirection Left()
        {
            _cardinalDirectionManager = _cardinalDirectionManager.TurnLeft();
            return _cardinalDirectionManager.CardinalDirection;
        }

        public void Report()
        {
            ToyRobotState toyRobotState = GetState();
            _reportManager.Report(toyRobotState);
        }

        public ToyRobotState GetState()
        {
            return new ToyRobotState(_position, _cardinalDirectionManager.CardinalDirection);
        }
    }
}
