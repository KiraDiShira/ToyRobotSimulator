using System.IO;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.CommandsFileReader
{
    public class SystemIoFileReader : IFileReader
    {
        public string ReadAllText(string directory, string path)
        {
            if (path is null)
            {
                throw new System.ArgumentNullException(nameof(path));
            }

            string filePath = Path.Combine(directory, path);

            return File.ReadAllText(filePath);
        }
    }
}
