using System;
using ToyRobotSimulator.ConsoleApp.ApplicationLogic;
using ToyRobotSimulator.ConsoleApp.BusinessLogic;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.Commands;
using ToyRobotSimulator.ConsoleApp.BusinessLogic.CommandsFileReader;

namespace ToyRobotSimulator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IErrorReporter errorReporter = new ErrorReporter();
            try
            {
                var commandsReader = new CommandsReader(new SystemIoFileReader());
                string[] commands = commandsReader.GetCommands("commands.txt");

                IPlaceManager placeManager = new PlaceManager();
                var toyRobotSimulator = new Simulator(placeManager, errorReporter);
                toyRobotSimulator.Run(commands);
            }
            catch (Exception exception)
            {
                errorReporter.Send(exception);               
            }
            Console.Read();
        }
    }
}
