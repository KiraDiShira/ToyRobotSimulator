using System;

namespace ToyRobotSimulator.ConsoleApp.ParameterObjects
{
    public class Position
    {
        public int SquareTabletopSize { get; set; } = 5;
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            if (x < 0 || x > SquareTabletopSize - 1)
            {
                throw new InvalidOperationException($"x value is out of range: {x}; SquareTabletopSize: {SquareTabletopSize}");
            }

            if (y < 0 || y > SquareTabletopSize - 1)
            {
                throw new InvalidOperationException($"y value is out of range: {y}; SquareTabletopSize: {SquareTabletopSize}");
            }

            X = x;
            Y = y;
        }
    }
}
