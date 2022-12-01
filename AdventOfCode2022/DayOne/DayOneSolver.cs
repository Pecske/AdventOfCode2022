using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayOne
{
    internal class DayOneSolver : BaseAdventSolver<List<Elf>>
    {

        public DayOneSolver() : base()
        {
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
