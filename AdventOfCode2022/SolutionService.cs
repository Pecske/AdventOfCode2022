using AdventOfCode2022.DayOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class SolutionService
    {
        private InputProcessService inputProcessService;

        private Dictionary<AdventDays, ISolution> solutions;



        private List<string> inputs;

        public SolutionService()
        {
            this.inputProcessService = InputProcessService.Instance;
            InitInputs();
            InitSolutions();
        }

        public void PrintSolution(AdventDays adventDays)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine(adventDays.ToString());
            AdventSolution solution = solutions[adventDays].GetSolution(this.inputs);
            Console.WriteLine(solution.ToString());
            Console.WriteLine("-------------------");
        }
        private void InitInputs()
        {
            FileHandler fileHandler = new FileHandler(AdventDays.DayOne.ToString());

            this.inputs = fileHandler.GetInput();
        }
        private void InitSolutions()
        {
            solutions = new Dictionary<AdventDays, ISolution>();
            SolutionDescription<List<Elf>> solutionDescription = new SolutionDescription<List<Elf>>(this.inputProcessService.GetElves, new DayOneSolver());
            solutions.Add(AdventDays.DayOne, solutionDescription);
        }
    }
}
