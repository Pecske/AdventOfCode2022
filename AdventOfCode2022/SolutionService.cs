using AdventOfCode2022.DayFive;
using AdventOfCode2022.DayFour;
using AdventOfCode2022.DayOne;
using AdventOfCode2022.DayThree;
using AdventOfCode2022.DayTwo;
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

        private FileHandler fileHandler;

        public SolutionService()
        {
            this.inputProcessService = InputProcessService.Instance;
            this.fileHandler = new FileHandler();
            InitSolutions();
        }

        public void PrintSolution(AdventDays adventDays)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine(adventDays.ToString());
            string? solution = solutions[adventDays].GetSolution(fileHandler.GetInput(adventDays.ToString())).ToString();
            Console.WriteLine(solution);
            Console.WriteLine("-------------------");
        }
        private void InitSolutions()
        {
            solutions = new Dictionary<AdventDays, ISolution>();
            SolutionDescription<List<Elf>, int> dayOneSolution = new SolutionDescription<List<Elf>, int>(this.inputProcessService.GetElves, new CalorieCounting());
            solutions.Add(AdventDays.DayOne, dayOneSolution);
            SolutionDescription<List<RPS>, int> dayTwoSolution = new SolutionDescription<List<RPS>, int>(this.inputProcessService.GetRPSs, new RockPaperScissors());
            solutions.Add(AdventDays.DayTwo, dayTwoSolution);
            SolutionDescription<List<string>, int> dayThreeSolution = new SolutionDescription<List<string>, int>(this.inputProcessService.GetRuckSacks, new RucksackReorganization());
            solutions.Add(AdventDays.DayThree, dayThreeSolution);
            SolutionDescription<List<SectionCleanUp>, int> dayFourSolution = new SolutionDescription<List<SectionCleanUp>, int>(this.inputProcessService.GetSections, new CampCleanup());
            solutions.Add(AdventDays.DayFour, dayFourSolution);
            SolutionDescription<List<SupplyCommand>, string> dayFiveSolution = new SolutionDescription<List<SupplyCommand>, string>(this.inputProcessService.GetSupplyCommands, new SupplyStacks());
            solutions.Add(AdventDays.DayFive, dayFiveSolution);
        }
    }
}
