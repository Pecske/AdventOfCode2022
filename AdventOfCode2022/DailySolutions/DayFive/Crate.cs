using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DayFive
{
    internal class Crate
    {
        public Dictionary<int, List<string>> Crates { get; private set; }

        public List<SupplyCommand> SupplyCommands { get; private set; }

        public Crate(Dictionary<int, List<string>> crates, List<SupplyCommand> supplyCommands)
        {
            Crates = crates;
            SupplyCommands = supplyCommands;
        }
    }
}
