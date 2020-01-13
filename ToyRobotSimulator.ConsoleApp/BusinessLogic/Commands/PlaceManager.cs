using System;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.Commands
{
    public class PlaceManager : IPlaceManager
    {
        public ToyRobot PlaceRobotOnTable(string command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            string[] commandComponents = command.Split(' ');
            string commandType = commandComponents[0];
            if (commandType != Constants.Commands.PLACE)
            {
                throw new InvalidOperationException($"this is not a place command: {command}");
            }

            if (commandComponents.Length != 2)
            {
                throw new InvalidOperationException($"invalid place command: {command}");
            }

            string commandArguments = commandComponents[1];
            PlaceArguments placeArguments = GetPlaceArguments(commandArguments);
            IReportManager reportManager = new ReportManager();
            var robot = new ToyRobot(placeArguments.Position, placeArguments.CardinalDirectionManager, reportManager);
            return robot;
        }

        private static PlaceArguments GetPlaceArguments(string arguments)
        {
            string[] placeArguments = arguments.Split(',');
            if (placeArguments.Length != 3)
            {
                throw new InvalidOperationException($"invalid number of arguments for place command: {placeArguments.Length}");
            }
            if (!int.TryParse(placeArguments[0], out int x))
            {
                throw new InvalidOperationException($"x is not a number: {placeArguments[0]}");
            }
            if (!int.TryParse(placeArguments[1], out int y))
            {
                throw new InvalidOperationException($"y is not a number: {placeArguments[1]}");
            }

            ICardinalDirectionManager cardinalDirectionManager = GetCardinalDirectionManager(placeArguments[2]);
            return new PlaceArguments()
            {
                Position = new Position(x, y),
                CardinalDirectionManager = cardinalDirectionManager
            };
        }

        private static ICardinalDirectionManager GetCardinalDirectionManager(string cardinalDirection)
        {
            switch (cardinalDirection)
            {
                case Constants.CardinalDirections.NORTH:
                    return new NorthManager();
                case Constants.CardinalDirections.SOUTH:
                    return new SouthManager();
                case Constants.CardinalDirections.WEST:
                    return new WestManager();
                case Constants.CardinalDirections.EAST:
                    return new EastManager();
            }
            throw new InvalidOperationException($"invalid value for cardinal position: {cardinalDirection}");
        }
    }
}
