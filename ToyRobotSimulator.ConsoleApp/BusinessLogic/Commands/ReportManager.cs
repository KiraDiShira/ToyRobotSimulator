using System;
using ToyRobotSimulator.ConsoleApp.ParameterObjects;

namespace ToyRobotSimulator.ConsoleApp.BusinessLogic.Commands
{
    public class ReportManager : IReportManager
    {
        public void Report(ToyRobotState toyRobotState)
        {
            Console.WriteLine($"{toyRobotState}");
        }
    }
}
