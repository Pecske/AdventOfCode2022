using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DTO
{
    public class AdventSolution<T>
    {
        public T PartOne { get; private set; }
        public T PartTwo { get; private set; }

        public AdventSolution(T partOne, T partTwo)
        {
            PartOne = partOne;
            PartTwo = partTwo;
        }

        public override string? ToString()
        {
            return $"Part One:\t{PartOne}\nPart Two:\t{PartTwo}";
        }
    }
}
