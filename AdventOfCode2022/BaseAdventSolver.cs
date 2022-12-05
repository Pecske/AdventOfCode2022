using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal abstract class BaseAdventSolver<T, U> : ISolver
    {
        protected Func<List<string>, T> InputProcessor { get; set; }

        protected InputProcessService InputProcessService { get; private set; }


        public BaseAdventSolver()
        {
            this.InputProcessService = InputProcessService.Instance;
            SetInputProcessor();
        }
        public AdventSolution<object> GetSolution(List<string> inputs)
        {
            T processedInput = InputProcessor(inputs);
            return new AdventSolution<object>(SolvePartOne(processedInput), SolvePartTwo(processedInput));
        }

        protected abstract void SetInputProcessor();
        protected abstract U SolvePartOne(T processedInput);
        protected abstract U SolvePartTwo(T processedInput);
    }
}
