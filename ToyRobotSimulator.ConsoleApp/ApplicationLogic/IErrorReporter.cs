using System;

namespace ToyRobotSimulator.ConsoleApp.ApplicationLogic
{
    public interface IErrorReporter
    {
        void Send(Exception exception);
    }
}