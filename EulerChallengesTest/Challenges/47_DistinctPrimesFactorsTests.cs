using EulerChallenges.Challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Challenges;

namespace EulerChallengesTest.Challenges
{
    [TestClass]
    public class _47_DistinctPrimesFactorsTests
    {
        [TestMethod]
        public void finds_14_when_passed_2()
        {
            IChallenge<int> chall = new _47_DistinctPrimesFactors(2);
            var result = chall.Run();
            var expected = 14;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void finds_644_when_passed_3()
        {
            IChallenge<int> chall = new _47_DistinctPrimesFactors(3);
            var result = chall.Run();
            var expected = 644;
            Assert.AreEqual(expected, result);
        }
    }
}
