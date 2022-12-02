using AdventOfCode2022.DayOne;
using AdventOfCode2022.DayTwo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class InputProcessService
    {
        private static InputProcessService instance;
        public static InputProcessService Instance { get { if (instance == null) { instance = new InputProcessService(); } return instance; } }

        public List<Elf> GetElves(List<string> inputs)
        {
            List<Elf> elves = new List<Elf>();
            int newElfCounter = 0;
            List<int> calories = new List<int>();
            foreach (var item in inputs)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    int calorie;
                    if (int.TryParse(item, out calorie))
                    {
                        calories.Add(calorie);
                    }
                }
                else
                {
                    Elf newElf = new Elf(newElfCounter, calories);
                    elves.Add(newElf);
                    calories = new List<int>();
                    newElfCounter++;
                }
            }
            return elves;
        }

        public List<RPS> GetRPSs(List<string> inputs)
        {
            List<RPS> rpsList = new List<RPS>();
            foreach (var item in inputs)
            {
                string[] hand = item.Split(" ");
                RPS rps = new RPS(hand[0], hand[1]);
                rpsList.Add(rps);
            }

            return rpsList;
        }
    }
}
