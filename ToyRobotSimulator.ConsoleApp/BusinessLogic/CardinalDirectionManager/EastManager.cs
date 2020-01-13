using System;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;
using ToyRobotSimulator.ConsoleApp.Enums;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager
{
    public class EastManager : ICardinalDirectionManager
    {
        public CardinalDirection CardinalDirection { get; } = CardinalDirection.EAST;

        public Position TryMoveAhead(Position position)
        {
            if (position is null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            if (CanMoveAhead(position))
            {
                position.X++;
            }
            return position;
        }

        private static bool CanMoveAhead(Position position)
        {
            return position.X < position.SquareTabletopSize - 1;
        }

        public ICardinalDirectionManager TurnRight()
        {
            return new SouthManager();
        }

        public ICardinalDirectionManager TurnLeft()
        {
            return new NorthManager();
        }
    }
}
