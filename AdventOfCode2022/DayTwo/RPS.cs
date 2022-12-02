using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayTwo
{
    internal class RPS
    {

        public string EnemyHand { get; private set; }
        public string OwnHand { get; private set; }

        public RPS(string enemyHand, string ownHand)
        {
            this.EnemyHand = enemyHand;
            this.OwnHand = ownHand;
        }

        public override bool Equals(object? obj)
        {
            return obj is RPS rPS &&
                   EnemyHand == rPS.EnemyHand &&
                   OwnHand == rPS.OwnHand;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EnemyHand, OwnHand);
        }
    }
}
