using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.Commands
{
    public interface IReportManager
    {
        void Report(ToyRobotState toyRobotState);
    }
}
