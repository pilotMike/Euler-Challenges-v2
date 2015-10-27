using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EulerTools_FSharp;
using System.Collections.Generic;

namespace EulerToolsTests.FSharp
{
    [TestClass]
    public class ChallengesTests
    {
        [TestMethod]
        public void ConsecutivePrimeSumBelow100()
        {


            //var result = EulerTools_FSharp.Challenges.ConsecutivePrimes(100);
            var result = EulerTools_FSharp.Challenges.ConsecutivePrimeSums(100);
            Assert.AreEqual(6, result);
        }
    }

    public static class Extensions
    {
        public static int SumWhile(this IEnumerable<int> source, Predicate<int> predicate)
        {
            int sum = 0;
            foreach (var e in source)
                if (predicate(e))
                    sum += e;
                else break;
            return sum;
        }
    }

}
