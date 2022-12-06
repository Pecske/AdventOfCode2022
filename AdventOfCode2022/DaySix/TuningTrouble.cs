using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DaySix
{
    internal class TuningTrouble : BaseAdventSolver<List<string>, int>
    {
        protected override void SetInputProcessor()
        {
            this.InputProcessor = this.InputProcessService.GetInputs;
        }

        protected override int SolvePartOne(List<string> processedInput)
        {
            return processedInput.Select(item => DistinctAmountFound(CommonConstant.DaySix.PacketMarker, item)).First();
        }

        protected override int SolvePartTwo(List<string> processedInput)
        {
            return processedInput.Select(item => DistinctAmountFound(CommonConstant.DaySix.MessageMarker, item)).First();
        }

        private int DistinctAmountFound(int markerLength, string dataStream)
        {
            int result = 0;
            bool resultFound = false;
            for (int i = 0; i < dataStream.Length && !resultFound; i++)
            {
                List<string> tempList = GetDistincts(markerLength, dataStream, i);
                if (tempList.Count == markerLength)
                {
                    resultFound = true;
                    result = i + markerLength;
                }
            }
            return result;
        }

        private List<string> GetDistincts(int markerLength, string dataStream, int currentIndex)
        {
            List<string> distinctList = new List<string>();
            bool isReset = false;
            for (int j = 0; j < markerLength && !isReset; j++)
            {
                string currentItem = dataStream[currentIndex + j].ToString();
                if (distinctList.Contains(currentItem))
                {
                    distinctList = new List<string>();
                    isReset = true;
                }
                else
                {
                    distinctList.Add(currentItem);
                }
            }
            return distinctList;
        }
    }
}
