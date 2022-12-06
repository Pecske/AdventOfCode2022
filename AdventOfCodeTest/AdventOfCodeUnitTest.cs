namespace AdventOfCodeTest
{
    using AdventOfCode2022;
    using System.Configuration;

    [TestClass]
    public class AdventOfCodeUnitTest
    {
        private static readonly string TestInputLocation = @"F:\Other\Repos\AdventOfCode2022\AdventOfCodeTest\Files\";
        private SolverService solverService;

        public AdventOfCodeUnitTest()
        {
            this.solverService = SolverService.GetInstance(TestInputLocation);
        }
        [TestMethod]
        public void TestDayOneExampleSolution()
        {
            AdventSolution<object> solution = this.solverService.GetAdventSolution(AdventDays.DayOne);
            Assert.AreEqual(solution.PartOne, 24000);
            Assert.AreEqual(solution.PartTwo, 45000);
        }
    }
}