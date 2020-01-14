using System.IO;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.CommandsFileReader
{
    public class SystemIoFileReader : IFileReader
    {
        public string ReadAllText(string directory, string filePath)
        {
            if (filePath is null)
            {
                throw new System.ArgumentNullException(nameof(filePath));
            }
            var file = Path.Combine(directory, filePath);
            return File.ReadAllText(file);
        }
    }
}
