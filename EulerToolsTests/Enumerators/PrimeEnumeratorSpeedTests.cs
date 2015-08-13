using System;
using EulerTools.Enumerators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EulerToolsTests.Enumerators
{
    [TestClass]
    public class PrimeEnumeratorSpeedTests
    {
        private const int iters = 1000000;

        //15.313
        [TestMethod]
        public void unchecked_speed_test()
        {
            var e = new PrimeEnumeratorUnchecked().GetEnumerator();
            for (int i = 0; i < iters; i++)
            {
                e.MoveNext();
            }

            Assert.IsTrue(true);
        }

        // 15.352
        [TestMethod]
        public void checked_speed_test()
        {
            var e = new PrimeEnumerator().GetEnumerator();
            for (int i = 0; i < iters; i++)
            {
                e.MoveNext();
            }

            Assert.IsTrue(true);
        }
    }
}
