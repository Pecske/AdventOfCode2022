using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal abstract class BaseAdventSolver<T, U>
    {

        public BaseAdventSolver()
        {
        }

        protected abstract U SolvePartOne(T processedInput);
        protected abstract U SolvePartTwo(T processedInput);

        public virtual List<U> SolveDay(T processedInput)
        {
            List<U> solutions = new List<U>();

            solutions.Add(SolvePartOne(processedInput));
            solutions.Add(SolvePartTwo(processedInput));

            return solutions;
        }
    }
}
