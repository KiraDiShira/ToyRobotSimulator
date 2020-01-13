using System;
using ToyRobotSimulator.ConsoleApp.Enums;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager
{
    public class SouthManager : ICardinalDirectionManager
    {
        public CardinalDirection CardinalDirection { get; } = CardinalDirection.SOUTH;

        public Position TryMoveAhead(Position position)
        {
            if (position is null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            if (CanMoveAhead(position))
            {
                position.Y--;
            }
            return position;
        }

        private static bool CanMoveAhead(Position position)
        {
            return position.Y > 0;
        }

        public ICardinalDirectionManager TurnRight()
        {
            return new WestManager();
        }

        public ICardinalDirectionManager TurnLeft()
        {
            return new EastManager();
        }
    }
}