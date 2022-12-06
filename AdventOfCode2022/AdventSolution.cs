using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class AdventSolution<T>
    {
        public T PartOne { get; private set; }
        public T PartTwo { get; private set; }

        public AdventSolution(T partOne, T partTwo)
        {
            this.PartOne = partOne;
            this.PartTwo = partTwo;
        }

        public override string? ToString()
        {
            return $"Part One:\t{this.PartOne}\nPart Two:\t{this.PartTwo}";
        }
    }
}
