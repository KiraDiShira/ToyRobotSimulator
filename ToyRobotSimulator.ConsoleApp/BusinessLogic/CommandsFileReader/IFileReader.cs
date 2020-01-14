namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.CommandsFileReader
{
    public interface IFileReader
    {
        string ReadAllText(string dir, string fileName);
    }
}
