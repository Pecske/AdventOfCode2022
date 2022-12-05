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
    internal class SolverService
    {
        private static SolverService instance;
        public static SolverService Instance { get { if (instance == null) { instance = new SolverService(); } return instance; } }

        private Dictionary<AdventDays, ISolver> solutions;

        private FileHandler fileHandler;

        private SolverService()
        {
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
            solutions = new Dictionary<AdventDays, ISolver>();
            solutions.Add(AdventDays.DayOne, new CalorieCounting());
            solutions.Add(AdventDays.DayTwo, new RockPaperScissors());
            solutions.Add(AdventDays.DayThree, new RucksackReorganization());
            solutions.Add(AdventDays.DayFour, new CampCleanup());
            solutions.Add(AdventDays.DayFive, new SupplyStacks());
        }
    }
}
