using AdventOfCode2022.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DayEight
{
    internal class TreetopTreeHouse : BaseAdventSolver<Forest, int>
    {
        protected override void SetInputProcessor()
        {
            this.InputProcessor = this.InputProcessService.GetForest;
        }

        protected override int SolvePartOne(Forest processedInput)
        {
            return processedInput.Trees.Where(item => !processedInput.IsTreeOnEdge(item.Key) && IsVisibleFromAnyDirection(processedInput, item)
                                                      || processedInput.IsTreeOnEdge(item.Key))
                                       .Count();
        }

        protected override int SolvePartTwo(Forest processedInput)
        {
            return processedInput.Trees.Where(item => !processedInput.IsTreeOnEdge(item.Key))
                                       .Select(item => GetScenicScoreByTree(processedInput, item))
                                       .Max();
        }
        private bool IsVisibleFromAnyDirection(Forest forest, KeyValuePair<Coordinate, int> currentTree)
        {
            Dictionary<Coordinate, int> trees = forest.Trees;
            bool visibleLeft = forest.GetCoordsFromLeftEdge(currentTree.Key).Select(treeItem => trees[treeItem]).All(treeValue => currentTree.Value > treeValue);
            bool visibleRight = forest.GetCoordsFromRightEdge(currentTree.Key).Select(treeItem => trees[treeItem]).All(treeValue => currentTree.Value > treeValue);
            bool visibleUp = forest.GetCoordsFromUpEdge(currentTree.Key).Select(treeItem => trees[treeItem]).All(treeValue => currentTree.Value > treeValue);
            bool visibleDown = forest.GetCoordsFromDownEdge(currentTree.Key).Select(treeItem => trees[treeItem]).All(treeValue => currentTree.Value > treeValue);

            return visibleLeft || visibleRight || visibleDown || visibleUp;
        }
        private int GetScenicScoreByTree(Forest forest, KeyValuePair<Coordinate, int> currentTree)
        {
            List<int> tempScore = new List<int>();
            List<int> leftEdgeTrees = forest.GetCoordsFromLeftEdge(currentTree.Key)
                                            .OrderByDescending(item => item.XPosition)
                                            .Select(item => forest.Trees[item])
                                            .ToList();
            tempScore.Add(GetScenicScoreFromEdge(leftEdgeTrees, currentTree.Value));
            List<int> rightEdgeTrees = forest.GetCoordsFromRightEdge(currentTree.Key)
                                             .OrderBy(item => item.XPosition)
                                             .Select(item => forest.Trees[item])
                                             .ToList();
            tempScore.Add(GetScenicScoreFromEdge(rightEdgeTrees, currentTree.Value));
            List<int> upEdgeTrees = forest.GetCoordsFromUpEdge(currentTree.Key)
                                          .OrderByDescending(item => item.YPosition)
                                          .Select(item => forest.Trees[item])
                                          .ToList();
            tempScore.Add(GetScenicScoreFromEdge(upEdgeTrees, currentTree.Value));
            List<int> downEdgeTrees = forest.GetCoordsFromDownEdge(currentTree.Key)
                                            .OrderBy(item => item.YPosition)
                                            .Select(item => forest.Trees[item])
                                            .ToList();
            tempScore.Add(GetScenicScoreFromEdge(downEdgeTrees, currentTree.Value));
            return tempScore.Aggregate((prev, current) => prev * current);
        }
        private int GetScenicScoreFromEdge(List<int> edgeTrees, int compareValue)
        {
            int result = 0;
            bool found = false;
            for (int i = 0; i < edgeTrees.Count && !found; i++)
            {
                int compareTreeValue = edgeTrees[i];
                if (compareValue > compareTreeValue)
                {
                    result++;
                }
                else
                {
                    result++;
                    found = true;
                }
            }
            return result;
        }
    }
}
