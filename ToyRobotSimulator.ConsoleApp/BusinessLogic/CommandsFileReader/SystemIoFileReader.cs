using System.IO;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.CommandsFileReader
{
    public class SystemIoFileReader : IFileReader
    {
        public string ReadAllText(string path)
        {
            if (path is null)
            {
                throw new System.ArgumentNullException(nameof(path));
            }

            string filePath = Path.Combine(path);

            return File.ReadAllText(filePath);
        }
    }
}
