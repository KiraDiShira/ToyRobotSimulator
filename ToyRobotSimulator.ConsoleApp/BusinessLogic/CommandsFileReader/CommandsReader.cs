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

        public string[] GetCommands(string filePath)
        {
            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            string commandsFile = _fileReader.ReadAllText(filePath);
            string[] commands = commandsFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return commands;
        }
    }
}
