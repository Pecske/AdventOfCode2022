﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class CommonConstant
    {
        public static readonly string FileExtension = ".txt";
        public class DayOne
        {
            public static readonly int TopElfCount = 3;
        }
        public class DayTwo
        {
            public static readonly int RockScore = 1;
            public static readonly int PaperScore = 2;
            public static readonly int ScissorsScore = 3;
            public static readonly int LoseScore = 0;
            public static readonly int DrawScore = 3;
            public static readonly int WinScore = 6;
            public static readonly string EnemyRock = "A";
            public static readonly string EnemyPaper = "B";
            public static readonly string EnemyScissor = "C";
            public static readonly string PlayerRock = "X";
            public static readonly string PlayerPaper = "Y";
            public static readonly string PlayerScissor = "Z";
        }
        public class DayThree
        {
            public static readonly string ABC = "abcdefghijklmnopqrstuvwxyz";
            public static readonly string UpperABC = ABC.ToUpper();
            public static readonly int UpperBonus = 26;
        }
    }
}
