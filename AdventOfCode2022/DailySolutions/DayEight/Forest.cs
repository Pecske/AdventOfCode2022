using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DayEight
{
    internal class Forest
    {
        public Dictionary<Coordinate, int> Trees { get; private set; }

        public int LeftEdge { get; private set; }
        public int RightEdge { get; private set; }
        public int UpEdge { get; private set; }
        public int DownEdge { get; private set; }

        public Forest(Dictionary<Coordinate, int> trees)
        {
            this.Trees = trees;
            foreach (var item in trees)
            {
                Coordinate currentCoord = item.Key;
                if (currentCoord.XPosition < LeftEdge)
                {
                    LeftEdge = currentCoord.XPosition;
                }
                else if (currentCoord.XPosition > RightEdge)
                {
                    RightEdge = currentCoord.XPosition;
                }
                if (currentCoord.YPosition < UpEdge)
                {
                    UpEdge = currentCoord.YPosition;
                }
                else if (currentCoord.YPosition > DownEdge)
                {
                    DownEdge = currentCoord.YPosition;
                }
            }
        }
        public bool IsTreeOnEdge(Coordinate currentTree)
        {
            return currentTree.XPosition == this.LeftEdge
                     || currentTree.XPosition == this.RightEdge
                     || currentTree.YPosition == this.UpEdge
                     || currentTree.YPosition == this.DownEdge;
        }
        public List<Coordinate> GetCoordsFromLeftEdge(Coordinate currentTree)
        {
            Coordinate leftEdge = new Coordinate(this.LeftEdge, currentTree.YPosition);
            List<Coordinate> coords = leftEdge.FindCoordsInRow(currentTree);
            coords.Remove(currentTree);
            return coords;
        }
        public List<Coordinate> GetCoordsFromRightEdge(Coordinate currentTree)
        {
            Coordinate rightEdge = new Coordinate(this.RightEdge, currentTree.YPosition);
            List<Coordinate> coords = currentTree.FindCoordsInRow(rightEdge);
            coords.Add(rightEdge);
            coords.Remove(currentTree);
            return coords;
        }
        public List<Coordinate> GetCoordsFromUpEdge(Coordinate currentTree)
        {
            Coordinate upEdge = new Coordinate(currentTree.XPosition, this.UpEdge);
            List<Coordinate> coords = upEdge.FindCoordsInColumn(currentTree);
            coords.Remove(currentTree);
            return coords;
        }
        public List<Coordinate> GetCoordsFromDownEdge(Coordinate currentTree)
        {
            Coordinate downEdge = new Coordinate(currentTree.XPosition, this.DownEdge);
            List<Coordinate> coords = currentTree.FindCoordsInColumn(downEdge);
            coords.Add(downEdge);
            coords.Remove(currentTree);
            return coords;
        }
    }
}
