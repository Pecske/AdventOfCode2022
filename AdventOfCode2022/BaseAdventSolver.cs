using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal abstract class BaseAdventSolver<T>
    {

        public BaseAdventSolver()
        {
        }

        protected abstract int SolvePartOne(T processedInput);
        protected abstract int SolvePartTwo(T processedInput);

        public virtual List<int> SolveDay(T processedInput)
        {
            List<int> solutions = new List<int>();

            solutions.Add(SolvePartOne(processedInput));
            solutions.Add(SolvePartTwo(processedInput));

            return solutions;
        }
    }
}
