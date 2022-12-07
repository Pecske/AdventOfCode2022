using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DayFive
{
    internal class SupplyCommand
    {
        public int MoveAmount { get; private set; }
        public int MoveFrom { get; private set; }
        public int MoveTo { get; private set; }

        public SupplyCommand(int moveAmount, int moveFrom, int moveTo)
        {
            MoveAmount = moveAmount;
            MoveFrom = moveFrom;
            MoveTo = moveTo;
        }
    }
}
