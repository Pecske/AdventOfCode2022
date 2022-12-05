using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class SolutionDescription<T, U> : ISolution
    {
        private Func<List<string>, T> processInput;

        private BaseAdventSolver<T, U> adventSolver;

        public SolutionDescription(Func<List<string>, T> processInput, BaseAdventSolver<T, U> adventSolver)
        {
            this.processInput = processInput;
            this.adventSolver = adventSolver;
        }

        public AdventSolution<object> GetSolution(List<string> inputs)
        {
            List<U> solutions = Solve(inputs);
            return new AdventSolution<object>(solutions[0], solutions[1]);
        }

        private List<U> Solve(List<string> inputs)
        {
            return adventSolver.SolveDay(processInput(inputs));
        }
    }
}
