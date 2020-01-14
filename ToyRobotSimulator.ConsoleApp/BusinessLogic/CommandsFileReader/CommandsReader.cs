using System;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.CommandsFileReader
{
    public class CommandsReader
    {
        private readonly IFileReader _fileReader;

        public CommandsReader(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public string[] GetCommands(string fileName)
        {
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            string commandsFile = _fileReader.ReadAllText(fileName);
            string[] commands = commandsFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return commands;
        }
    }
}
