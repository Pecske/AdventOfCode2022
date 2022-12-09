using AdventOfCode2022.DailySolutions.DayEight;
using AdventOfCode2022.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DayNine
{
    internal class RopeBridge : BaseAdventSolver<List<MovementCommand>, int>
    {
        private static readonly double MinDiagonalDistance = Math.Sqrt(2);
        private static readonly Coordinate ZeroVector = new Coordinate(0, 0);
        private Dictionary<Direction, Coordinate> movementMap;

        public RopeBridge()
        {
            this.movementMap = new Dictionary<Direction, Coordinate>();
            InitMovementMap();
        }

        protected override void SetInputProcessor()
        {
            this.InputProcessor = this.InputProcessService.GetMovementCommands;
        }

        protected override int SolvePartOne(List<MovementCommand> processedInput)
        {
            Dictionary<int, List<Coordinate>> knotRoads = Enumerable.Range(0, 2)
                                                        .ToDictionary(key => key, value => new List<Coordinate>() { ZeroVector });
            MoveKnots(knotRoads, processedInput);
            return knotRoads[1].Distinct().Count();
        }

        protected override int SolvePartTwo(List<MovementCommand> processedInput)
        {
            Dictionary<int, List<Coordinate>> knotRoads = Enumerable.Range(0, 10)
                                                                    .ToDictionary(key => key, value => new List<Coordinate>() { ZeroVector });
            MoveKnots(knotRoads, processedInput);

            return knotRoads[9].Distinct().Count();
        }

        private void InitMovementMap()
        {
            this.movementMap.Add(Direction.U, new Coordinate(0, -1));
            this.movementMap.Add(Direction.R, new Coordinate(1, 0));
            this.movementMap.Add(Direction.D, new Coordinate(0, 1));
            this.movementMap.Add(Direction.L, new Coordinate(-1, 0));
        }
        private void MoveKnots(Dictionary<int, List<Coordinate>> knotRoads, List<MovementCommand> processedInput)
        {
            foreach (var item in processedInput)
            {
                Coordinate moveVector = this.movementMap[item.Direction];
                for (int i = 0; i < item.MoveAmount; i++)
                {
                    List<Coordinate> headRoads = knotRoads[0];
                    Coordinate newHeadPosition = headRoads.Last().AddCoordinate(moveVector);
                    headRoads.Add(newHeadPosition);
                    foreach (var currentTail in knotRoads)
                    {
                        if (currentTail.Key != 0)
                        {
                            Coordinate prevTailLatestCoordinate = knotRoads[currentTail.Key - 1].Last();
                            Coordinate currentTailPosition = currentTail.Value.Last();
                            if (currentTailPosition.GetDistance(prevTailLatestCoordinate) > MinDiagonalDistance)
                            {
                                Coordinate distanceVector = prevTailLatestCoordinate.SubtractCoordinate(currentTailPosition);
                                Coordinate tailMoveVector = GetTailMoveVectorByDistance(distanceVector);
                                Coordinate newTailPosition = currentTailPosition.AddCoordinate(tailMoveVector);
                                currentTail.Value.Add(newTailPosition);
                            }
                        }
                    }

                }
            }
        }
        private Coordinate GetTailMoveVectorByDistance(Coordinate distanceVector)
        {
            int xMoveAmount = 0;
            int yMoveAmount = 0;
            if (distanceVector.XPosition == 0)
            {
                xMoveAmount = 0;
            }
            else if (distanceVector.XPosition / 2 == 0)
            {
                xMoveAmount = distanceVector.XPosition;
            }
            else
            {
                xMoveAmount = distanceVector.XPosition / 2;
            }
            if (distanceVector.YPosition == 0)
            {
                yMoveAmount = 0;
            }
            else if (distanceVector.YPosition / 2 == 0)
            {
                yMoveAmount = distanceVector.YPosition;
            }
            else
            {
                yMoveAmount = distanceVector.YPosition / 2;
            }
            return new Coordinate(xMoveAmount, yMoveAmount);
        }
    }
}
