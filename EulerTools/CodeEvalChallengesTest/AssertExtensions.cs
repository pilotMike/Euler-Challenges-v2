using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeEvalChallengesTest
{
    public static class AssertExtensions
    {
        public static void AreEqual<T>(IEnumerable<T> expected, IEnumerable<T> result)
        {
            if (expected == null) throw new ArgumentException("source1 cannot be null");
            if (result == null) throw new ArgumentException("source2 cannot be null");

            var e1 = expected.GetEnumerator();
            var e2 = result.GetEnumerator();

            var e1Count = 0;
            var e2Count = 0;

            while (e1.MoveNext() && e2.MoveNext())
            {
                var el1 = e1.Current;
                var el2 = e2.Current;
                Assert.AreEqual(el1, el2);
                e1Count++;
                e2Count++;
            }

            Assert.AreEqual(e1Count, e2Count, 0, "two sources do not have the same number of elements");
        }
    }
}
