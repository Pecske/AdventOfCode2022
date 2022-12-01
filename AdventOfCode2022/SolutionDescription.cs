using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class SolutionDescription<T> : ISolution
    {
        private Func<List<string>, T> processInput;

        private BaseAdventSolver<T> adventSolver;

        public SolutionDescription(Func<List<string>, T> processInput, BaseAdventSolver<T> adventSolver)
        {
            this.processInput = processInput;
            this.adventSolver = adventSolver;
        }

        public AdventSolution GetSolution(List<string> inputs)
        {
            List<int> solutions = Solve(inputs);
            return new AdventSolution(solutions[0], solutions[1]);
        }

        private List<int> Solve(List<string> inputs)
        {
            return adventSolver.SolveDay(processInput(inputs));
        }
    }
}
