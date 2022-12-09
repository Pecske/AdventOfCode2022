using AdventOfCode2022.DTO;
using AdventOfCode2022.Utils;
using AdventOfCode2022.DailySolutions.DayOne;
using AdventOfCode2022.DailySolutions.DayTwo;
using AdventOfCode2022.DailySolutions.DayThree;
using AdventOfCode2022.DailySolutions.DayFour;
using AdventOfCode2022.DailySolutions.DayFive;
using AdventOfCode2022.DailySolutions.DaySix;
using AdventOfCode2022.DailySolutions.DaySeven;
using AdventOfCode2022.DailySolutions.DayEight;
using AdventOfCode2022.DailySolutions.DayNine;

namespace AdventOfCode2022.Service
{
    public class SolverService
    {
        private static SolverService? instance;

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
            fileHandler = new FileHandler(inputLocation);
            solutions = new Dictionary<AdventDays, ISolver>();
            InitSolutions();
        }
        public AdventSolution<object> GetAdventSolution(AdventDays advent)
        {
            return solutions[advent].GetSolution(fileHandler.GetInput(advent.ToString()));
        }
        private void InitSolutions()
        {
            solutions.Add(AdventDays.DayOne, new CalorieCounting());
            solutions.Add(AdventDays.DayTwo, new RockPaperScissors());
            solutions.Add(AdventDays.DayThree, new RucksackReorganization());
            solutions.Add(AdventDays.DayFour, new CampCleanup());
            solutions.Add(AdventDays.DayFive, new SupplyStacks());
            solutions.Add(AdventDays.DaySix, new TuningTrouble());
            solutions.Add(AdventDays.DaySeven, new NoSpaceLeftOnDevice());
            solutions.Add(AdventDays.DayEight, new TreetopTreeHouse());
            solutions.Add(AdventDays.DayNine, new RopeBridge());
        }
    }
}
