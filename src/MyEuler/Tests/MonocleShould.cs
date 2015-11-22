using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EulerMonocle;
using Utility;

namespace Tests
{
    [TestClass]
    public class MonocleShould
    {
        [TestMethod]
        public void HaveSameProblemNumberAsProblemIndex()
        {
            Int16 index = 1;

            Crack.Start();
            var solution = Monocle.Instance[index].GetSolution();
            Crack.Stop();
            Assert.AreEqual(index, solution.ProblemNumber);
        }
    }
}
