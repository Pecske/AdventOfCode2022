using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayThree
{
    internal class RucksackReorganization : BaseAdventSolver<List<string>>
    {
        protected override int SolvePartOne(List<string> processedInput)
        {
            int solution = 0;
            foreach (var item in processedInput)
            {
                string firstCompartment = item.Substring(0, item.Length / 2);
                string secondCompartment = item.Substring(item.Length / 2);
                List<string> container = new List<string>() { secondCompartment };
                solution += GetScoreInSackFromContainer(firstCompartment, container);
            }
            return solution;
        }

        protected override int SolvePartTwo(List<string> processedInput)
        {
            int score = 0;

            for (int i = 0; i < processedInput.Count; i += 3)
            {
                string firstItem = processedInput[i];
                string secondItem = processedInput[i + 1];
                string thirdItem = processedInput[i + 2];
                List<string> container = new List<string>() { secondItem, thirdItem };
                score += GetScoreInSackFromContainer(firstItem, container);
            }

            return score;
        }

        private int CalculateItemScore(char item)
        {
            if (!Char.IsUpper(item))
            {
                return (CommonConstant.DayThree.ABC.IndexOf(item) + 1);
            }
            else
            {
                return (CommonConstant.DayThree.UpperABC.IndexOf(item) + 1 + CommonConstant.DayThree.UpperBonus);
            }
        }
        private int GetScoreInSackFromContainer(string sack, List<string> container)
        {
            int score = 0;
            bool itemFound = false;
            for (int i = 0; i < sack.Length && !itemFound; i++)
            {
                char singleItem = sack[i];
                if (container.All(item => item.Contains(singleItem)))
                {
                    itemFound = true;
                    score += CalculateItemScore(singleItem);
                }
            }
            return score;
        }
    }
}
