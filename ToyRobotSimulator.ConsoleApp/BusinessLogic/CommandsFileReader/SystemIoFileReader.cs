using System.IO;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.CommandsFileReader
{
    public class SystemIoFileReader : IFileReader
    {
        public string ReadAllText(string filePath)
        {
            if (filePath is null)
            {
                throw new System.ArgumentNullException(nameof(filePath));
            }
            return File.ReadAllText(filePath);
        }
    }
}
