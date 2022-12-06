namespace AdventOfCodeTest
{
    using AdventOfCode2022.DTO;
    using AdventOfCode2022.Service;
    using AdventOfCode2022.Utils;
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
        [TestMethod]
        public void TestDayTwoExampleSolution()
        {
            AdventSolution<object> solution = this.solverService.GetAdventSolution(AdventDays.DayTwo);
            Assert.AreEqual(solution.PartOne, 15);
            Assert.AreEqual(solution.PartTwo, 12);
        }
        [TestMethod]
        public void TestDayThreeExampleSolution()
        {
            AdventSolution<object> solution = this.solverService.GetAdventSolution(AdventDays.DayThree);
            Assert.AreEqual(solution.PartOne, 157);
            Assert.AreEqual(solution.PartTwo, 70);
        }
        [TestMethod]
        public void TestDayFourExampleSolution()
        {
            AdventSolution<object> solution = this.solverService.GetAdventSolution(AdventDays.DayFour);
            Assert.AreEqual(solution.PartOne, 2);
            Assert.AreEqual(solution.PartTwo, 4);
        }
        [TestMethod]
        public void TestDayFiveExampleSolution()
        {
            AdventSolution<object> solution = this.solverService.GetAdventSolution(AdventDays.DayFive);
            Assert.AreEqual(solution.PartOne, "CMZ");
            Assert.AreEqual(solution.PartTwo, "MCD");
        }
        [TestMethod]
        public void TestDaySixExampleSolution()
        {
            AdventSolution<object> solution = this.solverService.GetAdventSolution(AdventDays.DaySix);
            Assert.AreEqual(solution.PartOne, 7);
            Assert.AreEqual(solution.PartTwo, 19);
        }
    }
}