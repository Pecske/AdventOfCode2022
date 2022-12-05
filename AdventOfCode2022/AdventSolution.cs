using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class AdventSolution<T>
    {
        private T partOne;

        private T partTwo;

        public AdventSolution(T partOne, T partTwo)
        {
            this.partOne = partOne;
            this.partTwo = partTwo;
        }

        public override string? ToString()
        {
            return $"Part One:\t{this.partOne}\nPart Two:\t{this.partTwo}";
        }
    }
}
