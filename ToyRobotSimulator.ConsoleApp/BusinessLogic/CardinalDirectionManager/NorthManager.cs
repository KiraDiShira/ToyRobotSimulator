using System;
using ToyRobotSimulator.ConsoleApp.Enums;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager
{
    public class NorthManager : ICardinalDirectionManager
    {
        public CardinalDirection CardinalDirection { get; } = CardinalDirection.NORTH;

        public Position TryMoveAhead(Position position)
        {
            if (position is null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            if (CanMoveAhead(position))
            {
                position.Y++;
            }

            return position;
        }

        private static bool CanMoveAhead(Position position)
        {
            return position.Y < position.SquareTabletopSize - 1;
        }

        public ICardinalDirectionManager TurnRight()
        {
            return new EastManager();
        }

        public ICardinalDirectionManager TurnLeft()
        {
            return new WestManager();
        }
    }
}

