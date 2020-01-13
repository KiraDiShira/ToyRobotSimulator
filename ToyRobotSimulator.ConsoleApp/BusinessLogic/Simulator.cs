using System;
using ToyRobotSimulator.ConsoleApp.ApplicationLogic;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.Commands;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic
{
    public class Simulator
    {
        private readonly IPlaceManager _placeManager;
        private readonly IErrorReporter _errorReporter;

        public Simulator(IPlaceManager placeManager, IErrorReporter errorReporter)
        {
            _placeManager = placeManager;
            _errorReporter = errorReporter;
        }

        public ToyRobotState Run(string[] commands)
        {
            if (commands is null)
            {
                throw new ArgumentNullException(nameof(commands));
            }

            ToyRobot toyRobot = null;
            foreach (string command in commands)
            {
                try
                {
                    toyRobot = ExecuteCommand(toyRobot, command);
                }
                catch (Exception exception)
                {
                    _errorReporter.Send(exception);
                }
            }
            return toyRobot?.GetState();
        }

        private ToyRobot ExecuteCommand(ToyRobot toyRobot, string command)
        {
            string[] commandComponents = command.Split(' ');
            string commandType = commandComponents[0];
            switch (commandType)
            {
                case Constants.Commands.PLACE:
                    toyRobot = _placeManager.PlaceRobotOnTable(command);
                    break;
                case Constants.Commands.MOVE:
                    ValidateNoArgumentsCommand(commandComponents);
                    toyRobot?.Move();
                    break;
                case Constants.Commands.LEFT:
                    ValidateNoArgumentsCommand(commandComponents);
                    toyRobot?.Left();
                    break;
                case Constants.Commands.RIGHT:
                    ValidateNoArgumentsCommand(commandComponents);
                    toyRobot?.Right();
                    break;
                case Constants.Commands.REPORT:
                    ValidateNoArgumentsCommand(commandComponents);
                    toyRobot?.Report();
                    break;
                default:
                    throw new InvalidOperationException($"invalid command: {command}");
            }

            return toyRobot;
        }

        private static void ValidateNoArgumentsCommand(string[] commandComponents)
        {
            if (commandComponents.Length != 1)
            {
                throw new InvalidOperationException($"invalid command {String.Join(' ', commandComponents)}");
            }
        }
    }
}
