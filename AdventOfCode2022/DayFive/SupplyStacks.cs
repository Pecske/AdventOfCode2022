using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayFive
{
    internal class SupplyStacks : BaseAdventSolver<List<SupplyCommand>, string>
    {
        private Dictionary<int, List<string>> crates = new Dictionary<int, List<string>>();

        public SupplyStacks() : base()
        {
            InitCrates();
        }
        protected override void SetInputProcessor()
        {
            this.InputProcessor = this.InputProcessService.GetSupplyCommands;
        }

        protected override string SolvePartOne(List<SupplyCommand> processedInput)
        {
            Dictionary<int, List<string>> copyCrates = CreateCrateCopy();
            processedInput.ForEach(item => MoveItemInCrates(copyCrates, item, false));
            return AggregateSolutionFromCrate(copyCrates);
        }

        protected override string SolvePartTwo(List<SupplyCommand> processedInput)
        {
            Dictionary<int, List<string>> copyCrates = CreateCrateCopy();
            processedInput.ForEach(item => MoveItemInCrates(copyCrates, item, true));
            return AggregateSolutionFromCrate(copyCrates);
        }

        private void InitCrates()
        {
            /*
            [D]                     [N] [F]    
            [H] [F]             [L] [J] [H]    
            [R] [H]             [F] [V] [G] [H]
            [Z] [Q]         [Z] [W] [L] [J] [B]
            [S] [W] [H]     [B] [H] [D] [C] [M]
            [P] [R] [S] [G] [J] [J] [W] [Z] [V]
            [W] [B] [V] [F] [G] [T] [T] [T] [P]
            [Q] [V] [C] [H] [P] [Q] [Z] [D] [W]
             1   2   3   4   5   6   7   8   9 
             */

            crates[1] = new List<string>() { "D", "H", "R", "Z", "S", "P", "W", "Q" };
            crates[2] = new List<string>() { "F", "H", "Q", "W", "R", "B", "V" };
            crates[3] = new List<string>() { "H", "S", "V", "C" };
            crates[4] = new List<string>() { "G", "F", "H" };
            crates[5] = new List<string>() { "Z", "B", "J", "G", "P" };
            crates[6] = new List<string>() { "L", "F", "W", "H", "J", "T", "Q" };
            crates[7] = new List<string>() { "N", "J", "V", "L", "D", "W", "T", "Z" };
            crates[8] = new List<string>() { "F", "H", "G", "J", "C", "Z", "T", "D" };
            crates[9] = new List<string>() { "H", "B", "M", "V", "P", "W" };
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
            return crates.Select(item => item.Value).Select(item => item[0]).Aggregate((current, next) => current + next);
        }
        private Dictionary<int, List<string>> CreateCrateCopy()
        {
            return this.crates.ToDictionary(entry => entry.Key, entry => new List<string>(entry.Value));
        }
    }
}
