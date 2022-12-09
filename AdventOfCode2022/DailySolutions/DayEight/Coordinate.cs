using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DayEight
{
    internal class Coordinate
    {
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }

        public Coordinate(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }
        public Coordinate AddCoordinate(Coordinate coordToAdd)
        {
            int newXPos = this.XPosition + coordToAdd.XPosition;
            int newYPos = this.YPosition + coordToAdd.YPosition;
            return new Coordinate(newXPos, newYPos);
        }
        public Coordinate SubtractCoordinate(Coordinate coordToSubtract)
        {
            int newXPos = this.XPosition - coordToSubtract.XPosition;
            int newYPos = this.YPosition - coordToSubtract.YPosition;
            return new Coordinate(newXPos, newYPos);
        }
        public double GetDistance(Coordinate distantCoordinate)
        {
            double distance = 0d;

            int xDistance = Math.Abs(this.XPosition - distantCoordinate.XPosition);
            int yDistance = Math.Abs(this.YPosition - distantCoordinate.YPosition);
            distance = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));

            return distance;
        }
        public List<Coordinate> FindCoordsInRow(Coordinate other)
        {
            int count = Math.Abs(XPosition - other.XPosition);
            return Enumerable.Range(XPosition, count)
                             .Select(item => new Coordinate(item, YPosition))
                             .ToList();

        }
        public List<Coordinate> FindCoordsInColumn(Coordinate other)
        {
            int count = Math.Abs(YPosition - other.YPosition);
            return Enumerable.Range(YPosition, count)
                             .Select(item => new Coordinate(XPosition, item))
                             .ToList();
        }
        public override bool Equals(object? obj)
        {
            return obj is Coordinate coordinate &&
                   XPosition == coordinate.XPosition &&
                   YPosition == coordinate.YPosition;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(XPosition, YPosition);
        }
    }
}
