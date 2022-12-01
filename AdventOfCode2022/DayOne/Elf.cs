using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayOne
{
    internal class Elf
    {
        public int ElfIndex { get; private set; }
        public List<int> Calories { get; private set; }

        public Elf(int elfIndex, List<int> calories)
        {
            ElfIndex = elfIndex;
            Calories = calories;
        }

        public int GetSumCalories()
        {
            return Calories.Sum();
        }
    }
}
