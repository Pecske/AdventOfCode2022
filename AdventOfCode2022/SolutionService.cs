﻿using AdventOfCode2022.DayOne;
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
            AdventSolution solution = solutions[adventDays].GetSolution(fileHandler.GetInput(adventDays.ToString()));
            Console.WriteLine(solution.ToString());
            Console.WriteLine("-------------------");
        }
        private void InitSolutions()
        {
            solutions = new Dictionary<AdventDays, ISolution>();
            SolutionDescription<List<Elf>> dayOneSolution = new SolutionDescription<List<Elf>>(this.inputProcessService.GetElves, new DayOneSolver());
            solutions.Add(AdventDays.DayOne, dayOneSolution);
            SolutionDescription<List<RPS>> dayTwoSolution = new SolutionDescription<List<RPS>>(this.inputProcessService.GetRPSs, new DayTwoSolver());
            solutions.Add(AdventDays.DayTwo, dayTwoSolution);
        }
    }
}