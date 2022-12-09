using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DayNine
{
    internal class MovementCommand
    {
        public Direction Direction { get; private set; }
        public int MoveAmount { get; private set; }

        public MovementCommand(Direction direction, int moveAmount)
        {
            Direction = direction;
            MoveAmount = moveAmount;
        }
    }
}
