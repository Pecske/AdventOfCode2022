using AdventOfCode2022.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayFour
{
    internal class CampCleanup : BaseAdventSolver<List<SectionCleanUp>, int>
    {
        protected override void SetInputProcessor()
        {
            this.InputProcessor = this.InputProcessService.GetSections;
        }

        protected override int SolvePartOne(List<SectionCleanUp> processedInput)
        {
            return processedInput.Where(item => isAllItemInList(item.FirstElfSequence, item.SecondElfSequence)
                                             || isAllItemInList(item.SecondElfSequence, item.FirstElfSequence))
                                 .Count();
        }

        protected override int SolvePartTwo(List<SectionCleanUp> processedInput)
        {
            return processedInput.Where(item => isAnyItemInList(item.FirstElfSequence, item.SecondElfSequence)
                                             || isAnyItemInList(item.SecondElfSequence, item.FirstElfSequence))
                                 .Count();
        }

        private bool isAllItemInList(List<int> itemList, List<int> compareList)
        {
            return itemList.All(listItem => compareList.Contains(listItem));
        }
        private bool isAnyItemInList(List<int> itemList, List<int> compareList)
        {
            return itemList.Any(listItem => compareList.Contains(listItem));
        }
    }
}
