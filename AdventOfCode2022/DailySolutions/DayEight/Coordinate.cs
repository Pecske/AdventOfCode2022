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
        public Coordinate AddToCoord(Coordinate coordinate)
        {
            int newXPos = this.XPosition + coordinate.XPosition;
            int newYPos = this.YPosition + coordinate.YPosition;
            return new Coordinate(newXPos, newYPos);
        }
        public List<Coordinate> FindBetween(Coordinate other)
        {
            List<Coordinate> inBetween = new List<Coordinate>() { other };
            List<Coordinate> xCoords = Enumerable.Range(this.XPosition, other.XPosition).Select(item => new Coordinate(item, this.YPosition)).ToList();
            List<Coordinate> yCoords = Enumerable.Range(this.YPosition, other.YPosition).Select(item => new Coordinate(this.XPosition, item)).ToList();
            inBetween.AddRange(xCoords);
            inBetween.AddRange(yCoords);

            return inBetween;
        }
        public List<Coordinate> FindCoordsInRow(Coordinate other)
        {
            int count = Math.Abs(this.XPosition - other.XPosition);
            return Enumerable.Range(this.XPosition, count)
                             .Select(item => new Coordinate(item, this.YPosition))
                             .ToList();

        }
        public List<Coordinate> FindCoordsInColumn(Coordinate other)
        {
            int count = Math.Abs(this.YPosition - other.YPosition);
            return Enumerable.Range(this.YPosition, count)
                             .Select(item => new Coordinate(this.XPosition, item))
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
