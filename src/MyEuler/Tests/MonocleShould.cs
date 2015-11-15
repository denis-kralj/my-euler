using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EulerMonocle;

namespace Tests
{
    [TestClass]
    public class MonocleShould
    {
        [TestMethod]
        public void HaveAnAdequateSolutionToTheFirstProblem()
        {
            // silly test to see if everything works
            var solution = Monocle.Instance[1].GetSolution();
            Assert.AreEqual(solution.Result, "233168");
        }

        [TestMethod]
        public void HaveSameProblemNumberAsProblemIndex()
        {
            Int16 index = 1;

            var solution = Monocle.Instance[index].GetSolution();
            Assert.AreEqual(index, solution.ProblemNumber);
        }
    }
}
