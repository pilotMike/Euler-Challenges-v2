using System;
using System.Text;
using System.Collections.Generic;
using EulerChallenges.Challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EulerChallengesTest.Challenges
{
    /// <summary>
    /// Summary description for _49_PrimePermutations
    /// </summary>
    [TestClass]
    public class _49_PrimePermutationsTests
    {
        [TestMethod]
        public void first_result()
        {
            var challenge = new _49_PrimePermutations(0);
            var output = challenge.Run();
            Assert.AreEqual("148748178147", output);
        }

        [TestMethod]
        public void second_result()
        {
            var challenge = new _49_PrimePermutations(1);
            var output = challenge.Run();
            Assert.IsTrue(true);
        }
    }
}
