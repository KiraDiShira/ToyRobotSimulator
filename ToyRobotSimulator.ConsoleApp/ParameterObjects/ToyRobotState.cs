using System;
using System.Collections.Generic;
using System.Text;
using ToyRobotSimulator.ConsoleApp.Enums;

namespace ToyRobotSimulator.ConsoleApp.ParameterObjects
{
    public class ToyRobotState
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public CardinalDirection CardinalDirection { get; private set; }

        public ToyRobotState(Position position, CardinalDirection cardinalDirection)
        {
            X = position.X;
            Y = position.Y;
            CardinalDirection = cardinalDirection;
        }

        public override string ToString()
        {
            return $"{X},{Y},{CardinalDirection}";
        }
    }
}
