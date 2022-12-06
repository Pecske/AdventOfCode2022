using AdventOfCode2022.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayFive
{
    internal class SupplyStacks : BaseAdventSolver<Crate, string>
    {

        protected override void SetInputProcessor()
        {
            this.InputProcessor = this.InputProcessService.GetSupplyCommands;
        }

        protected override string SolvePartOne(Crate processedInput)
        {
            Dictionary<int, List<string>> copyCrates = CreateCrateCopy(processedInput.Crates);
            processedInput.SupplyCommands.ForEach(item => MoveItemInCrates(copyCrates, item, false));
            return AggregateSolutionFromCrate(copyCrates);
        }

        protected override string SolvePartTwo(Crate processedInput)
        {
            Dictionary<int, List<string>> copyCrates = CreateCrateCopy(processedInput.Crates);
            processedInput.SupplyCommands.ForEach(item => MoveItemInCrates(copyCrates, item, true));
            return AggregateSolutionFromCrate(copyCrates);
        }

        private void MoveItemInCrates(Dictionary<int, List<string>> crates, SupplyCommand command, bool isInOrder)
        {
            List<string> from = crates[command.MoveFrom];
            List<string> to = crates[command.MoveTo];
            for (int i = 0; i < command.MoveAmount && from.Count > 0; i++)
            {
                string currentItem = from[0];
                from.Remove(currentItem);
                to.Insert((isInOrder) ? i : 0, currentItem);
            }
        }
        private string AggregateSolutionFromCrate(Dictionary<int, List<string>> crates)
        {
            return crates.OrderBy(item => item.Key)
                         .Select(item => item.Value)
                         .Select(item => item[0])
                         .Aggregate((current, next) => current + next);
        }
        private Dictionary<int, List<string>> CreateCrateCopy(Dictionary<int, List<string>> crates)
        {
            return crates.ToDictionary(entry => entry.Key, entry => new List<string>(entry.Value));
        }
    }
}
