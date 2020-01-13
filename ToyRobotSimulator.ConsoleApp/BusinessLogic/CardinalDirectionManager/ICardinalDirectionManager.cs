using ToyRobotSimulator.ConsoleApp.Enums;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager
{
    public interface ICardinalDirectionManager
    {
        CardinalDirection CardinalDirection { get; }
        Position TryMoveAhead(Position position);
        ICardinalDirectionManager TurnRight();
        public ICardinalDirectionManager TurnLeft();
    }
}
