using AdventOfCode2022.DayFive;
using AdventOfCode2022.DayFour;
using AdventOfCode2022.DayOne;
using AdventOfCode2022.DaySix;
using AdventOfCode2022.DayThree;
using AdventOfCode2022.DayTwo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class SolverService
    {
        private static SolverService instance;

        public static SolverService GetInstance(string inputLocation)
        {
            if (instance == null)
            {
                instance = new SolverService(inputLocation);
            }
            return instance;
        }

        private Dictionary<AdventDays, ISolver> solutions;

        private FileHandler fileHandler;

        private SolverService(string inputLocation)
        {
            this.fileHandler = new FileHandler(inputLocation);
            InitSolutions();
        }
        public AdventSolution<object> GetAdventSolution(AdventDays advent)
        {
            return solutions[advent].GetSolution(this.fileHandler.GetInput(advent.ToString()));
        }
        private void InitSolutions()
        {
            solutions = new Dictionary<AdventDays, ISolver>();
            solutions.Add(AdventDays.DayOne, new CalorieCounting());
            solutions.Add(AdventDays.DayTwo, new RockPaperScissors());
            solutions.Add(AdventDays.DayThree, new RucksackReorganization());
            solutions.Add(AdventDays.DayFour, new CampCleanup());
            solutions.Add(AdventDays.DayFive, new SupplyStacks());
            solutions.Add(AdventDays.DaySix, new TuningTrouble());
        }
    }
}
