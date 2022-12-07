using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DailySolutions.DayFour
{
    internal class SectionCleanUp
    {
        public string FirstElfSection { get; private set; }
        public string SecondElfSection { get; private set; }

        public List<int> FirstElfSequence { get; private set; }
        public List<int> SecondElfSequence { get; private set; }

        public SectionCleanUp(string firstElfSection, string secondElfSection)
        {
            this.FirstElfSection = firstElfSection;
            this.SecondElfSection = secondElfSection;
            this.FirstElfSequence = GetElfSequence(firstElfSection);
            this.SecondElfSequence = GetElfSequence(secondElfSection);
        }

        private List<int> GetElfSequence(string section)
        {
            List<int> sequence = new List<int>();
            int[] sections = section.Split("-").Select(item => int.Parse(item)).ToArray();
            int count = Math.Abs(sections[1] - sections[0]) + 1;
            return Enumerable.Range(sections[0], count).ToList();
        }
    }
}
