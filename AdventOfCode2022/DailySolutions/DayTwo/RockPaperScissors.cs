using AdventOfCode2022.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DayTwo
{
    internal class RockPaperScissors : BaseAdventSolver<List<RPS>, int>
    {
        private RPSTable table;
        public RockPaperScissors()
        {
            this.table = RPSTable.Instance;
        }

        protected override void SetInputProcessor()
        {
            this.InputProcessor = this.InputProcessService.GetRPSs;
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
