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
            Assert.AreEqual(24000,solution.PartOne );
            Assert.AreEqual(45000,solution.PartTwo );
        }
        [TestMethod]
        public void TestDayTwoExampleSolution()
        {
            AdventSolution<object> solution = this.solverService.GetAdventSolution(AdventDays.DayTwo);
            Assert.AreEqual(15,solution.PartOne);
            Assert.AreEqual(12,solution.PartTwo);
        }
        [TestMethod]
        public void TestDayThreeExampleSolution()
        {
            AdventSolution<object> solution = this.solverService.GetAdventSolution(AdventDays.DayThree);
            Assert.AreEqual(157,solution.PartOne);
            Assert.AreEqual(70,solution.PartTwo);
        }
        [TestMethod]
        public void TestDayFourExampleSolution()
        {
            AdventSolution<object> solution = this.solverService.GetAdventSolution(AdventDays.DayFour);
            Assert.AreEqual(2,solution.PartOne );
            Assert.AreEqual(4,solution.PartTwo );
        }
        [TestMethod]
        public void TestDayFiveExampleSolution()
        {
            AdventSolution<object> solution = this.solverService.GetAdventSolution(AdventDays.DayFive);
            Assert.AreEqual("CMZ",solution.PartOne);
            Assert.AreEqual("MCD",solution.PartTwo);
        }
        [TestMethod]
        public void TestDaySixExampleSolution()
        {
            AdventSolution<object> solution = this.solverService.GetAdventSolution(AdventDays.DaySix);
            Assert.AreEqual(7, solution.PartOne);
            Assert.AreEqual(19, solution.PartTwo);
        }
        [TestMethod]
        public void TestDaySevenExampleSolution()
        {
            AdventSolution<object> solution = this.solverService.GetAdventSolution(AdventDays.DaySeven);
            Assert.AreEqual(95437, solution.PartOne);
            Assert.AreEqual(24933642, solution.PartTwo);
        }
    }
}