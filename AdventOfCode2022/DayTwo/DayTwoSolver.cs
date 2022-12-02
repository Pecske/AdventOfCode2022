using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayTwo
{
    internal class DayTwoSolver : BaseAdventSolver<List<RPS>>
    {
        private RPSTable table;
        public DayTwoSolver()
        {
            this.table = RPSTable.Instance;
        }

        protected override int SolvePartOne(List<RPS> processedInput)
        {
            return processedInput.CalcRPSScore().Sum();
        }

        protected override int SolvePartTwo(List<RPS> processedInput)
        {
            return processedInput.Select(item => item.FindRPSFromResultTable()).CalcRPSScore().Sum();
        }

    }
}
