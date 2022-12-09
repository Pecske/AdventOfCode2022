// See https://aka.ms/new-console-template for more information
using AdventOfCode2022.Service;
using AdventOfCode2022.Utils;
using System.Configuration;
using System.Diagnostics;

string? path = ConfigurationManager.AppSettings.Get(CommonConstant.InputLocation);
SolverService solutionService = SolverService.GetInstance(path);

//PrintSolution(AdventDays.DayOne);
//PrintSolution(AdventDays.DayTwo);
//PrintSolution(AdventDays.DayThree);
//PrintSolution(AdventDays.DayFour);
//PrintSolution(AdventDays.DayFive);
//PrintSolution(AdventDays.DaySix);
//PrintSolution(AdventDays.DaySeven);
//PrintSolution(AdventDays.DayEight);
PrintSolution(AdventDays.DayNine);

void PrintSolution(AdventDays adventDays)
{
    Console.WriteLine("-------------------");
    Console.WriteLine(adventDays.ToString());
    Stopwatch sw = new Stopwatch();
    sw.Start();
    string? solution = solutionService.GetAdventSolution(adventDays).ToString();
    sw.Stop();
    Console.WriteLine(solution);
    Console.WriteLine("-------------------");
    Console.WriteLine("Elapsed Time:\t" + sw.Elapsed.ToString(@"ss\.fff"));
    Console.WriteLine("-------------------");
}

