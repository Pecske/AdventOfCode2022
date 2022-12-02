using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayTwo
{
    internal class RPSTable
    {
        private static RPSTable instance;

        private Dictionary<string, int> scoreTable;

        public Dictionary<RPS, int> ResultTable { get; private set; }

        public Dictionary<string, int> OutComeTable { get; private set; }

        public static RPSTable Instance { get { if (instance == null) { instance = new RPSTable(); } return instance; } }

        private RPSTable()
        {
            InitResultTable();
            InitScoreTable();
            InitOutComeTable();
        }

        public int GetResult(RPS rps)
        {
            return ResultTable[rps];
        }
        public int GetPlayedScore(string hand)
        {
            return scoreTable[hand];
        }

        private void InitResultTable()
        {
            this.ResultTable = new Dictionary<RPS, int>();
            this.ResultTable.Add(new RPS(CommonConstant.DayTwo.EnemyRock, CommonConstant.DayTwo.PlayerRock), CommonConstant.DayTwo.DrawScore);
            this.ResultTable.Add(new RPS(CommonConstant.DayTwo.EnemyRock, CommonConstant.DayTwo.PlayerPaper), CommonConstant.DayTwo.WinScore);
            this.ResultTable.Add(new RPS(CommonConstant.DayTwo.EnemyRock, CommonConstant.DayTwo.PlayerScissor), CommonConstant.DayTwo.LoseScore);
            this.ResultTable.Add(new RPS(CommonConstant.DayTwo.EnemyPaper, CommonConstant.DayTwo.PlayerRock), CommonConstant.DayTwo.LoseScore);
            this.ResultTable.Add(new RPS(CommonConstant.DayTwo.EnemyPaper, CommonConstant.DayTwo.PlayerPaper), CommonConstant.DayTwo.DrawScore);
            this.ResultTable.Add(new RPS(CommonConstant.DayTwo.EnemyPaper, CommonConstant.DayTwo.PlayerScissor), CommonConstant.DayTwo.WinScore);
            this.ResultTable.Add(new RPS(CommonConstant.DayTwo.EnemyScissor, CommonConstant.DayTwo.PlayerRock), CommonConstant.DayTwo.WinScore);
            this.ResultTable.Add(new RPS(CommonConstant.DayTwo.EnemyScissor, CommonConstant.DayTwo.PlayerPaper), CommonConstant.DayTwo.LoseScore);
            this.ResultTable.Add(new RPS(CommonConstant.DayTwo.EnemyScissor, CommonConstant.DayTwo.PlayerScissor), CommonConstant.DayTwo.DrawScore);
        }
        private void InitScoreTable()
        {
            this.scoreTable = new Dictionary<string, int>();
            this.scoreTable.Add(CommonConstant.DayTwo.PlayerRock, CommonConstant.DayTwo.RockScore);
            this.scoreTable.Add(CommonConstant.DayTwo.PlayerPaper, CommonConstant.DayTwo.PaperScore);
            this.scoreTable.Add(CommonConstant.DayTwo.PlayerScissor, CommonConstant.DayTwo.ScissorsScore);
        }
        private void InitOutComeTable()
        {
            this.OutComeTable = new Dictionary<string, int>();
            this.OutComeTable.Add(CommonConstant.DayTwo.PlayerRock, CommonConstant.DayTwo.LoseScore);
            this.OutComeTable.Add(CommonConstant.DayTwo.PlayerPaper, CommonConstant.DayTwo.DrawScore);
            this.OutComeTable.Add(CommonConstant.DayTwo.PlayerScissor, CommonConstant.DayTwo.WinScore);
        }
    }
}
