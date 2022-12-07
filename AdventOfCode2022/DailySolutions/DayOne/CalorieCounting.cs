using AdventOfCode2022.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DayOne
{
    internal class CalorieCounting : BaseAdventSolver<List<Elf>, int>
    {

        public CalorieCounting() : base()
        {
        }

        protected override void SetInputProcessor()
        {
            this.InputProcessor = this.InputProcessService.GetElves;
        }

        protected override int SolvePartOne(List<Elf> processedInput)
        {
            return processedInput.Select(item => item.GetSumCalories()).Max();
        }

        protected override int SolvePartTwo(List<Elf> processedInput)
        {
            int solution = 0;
            List<int> orderedCalories = processedInput.Select(item => item.GetSumCalories()).OrderByDescending(item => item).ToList();
            for (int i = 0; i < CommonConstant.DayOne.TopElfCount; i++)
            {
                solution += orderedCalories[i];
            }

            return solution;
        }

    }
}
