// See https://aka.ms/new-console-template for more information
using AdventOfCode2022;
using System.Configuration;

string? path = ConfigurationManager.AppSettings.Get(CommonConstant.InputLocation);
SolverService solutionService = SolverService.GetInstance(path);

PrintSolution(AdventDays.DayOne);
//PrintSolution(AdventDays.DayTwo);
//PrintSolution(AdventDays.DayThree);
//PrintSolution(AdventDays.DayFour);
//PrintSolution(AdventDays.DayFive);
PrintSolution(AdventDays.DaySix);

void PrintSolution(AdventDays adventDays)
{
    Console.WriteLine("-------------------");
    Console.WriteLine(adventDays.ToString());
    string? solution = solutionService.GetAdventSolution(adventDays).ToString();
    Console.WriteLine(solution);
    Console.WriteLine("-------------------");
}

