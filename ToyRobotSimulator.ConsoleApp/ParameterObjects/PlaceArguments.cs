using ToyRobotSimulator.ConsoleApp.BusinessLogic.CardinalDirectionManager;

namespace ToyRobotSimulator.ConsoleApp.ParameterObjects
{
    public class PlaceArguments
    {
        public Position Position { get; set; }
        public ICardinalDirectionManager CardinalDirectionManager { get; set; }
    }
}
