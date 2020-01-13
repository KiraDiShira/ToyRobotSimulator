using ToyRobotSimulator.ConsoleApp.Enums;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager
{
    public class WestManager : ICardinalDirectionManager
    {
        public CardinalDirection CardinalDirection { get; } = CardinalDirection.WEST;

        public Position TryMoveAhead(Position position)
        {
            if (position is null)
            {
                throw new System.ArgumentNullException(nameof(position));
            }

            if (CanMoveAhead(position))
                position.X--;
            return position;
        }

        private static bool CanMoveAhead(Position position)
        {
            return position.X > 0;
        }

        public ICardinalDirectionManager TurnRight()
        {
            return new NorthManager();
        }

        public ICardinalDirectionManager TurnLeft()
        {
            return new SouthManager();
        }
    }
}
