using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DayTwo
{
    internal static class RPSExtension
    {
        public static IEnumerable<int> CalcRPSScore(this IEnumerable<RPS> rpsList)
        {
            foreach (var rps in rpsList)
            {
                yield return RPSTable.Instance.GetResult(rps) + RPSTable.Instance.GetPlayedScore(rps.OwnHand);
            }
        }
        public static RPS FindRPSFromResultTable(this RPS rps)
        {
            return RPSTable.Instance.ResultTable.Where(tableItem => tableItem.Key.EnemyHand.Equals(rps.EnemyHand))
            .Where(tableItem => tableItem.Value == RPSTable.Instance.OutComeTable[rps.OwnHand])
            .Select(tableItem => tableItem.Key)
            .First();

        }
    }
}
