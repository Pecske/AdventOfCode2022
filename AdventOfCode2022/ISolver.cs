using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal interface ISolver
    {
        AdventSolution<object> GetSolution(List<string> inputs);
    }
}
