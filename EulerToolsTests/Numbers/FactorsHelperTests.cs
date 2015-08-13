using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EulerTools.Numbers;
using System.Linq;

namespace EulerToolsTests.Numbers
{
    /// <summary>
    /// Summary description for FactorsHelperTests
    /// </summary>
    [TestClass]
    public class FactorsHelperTests
    {
        public FactorsHelperTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        

        [TestMethod]
        public void fidns_factors_for_10()
        {
            var helper = new FactorsHelper();
            var result = helper.Factors(10);
            var expected = new[] { 2, 5 };
            Assert.IsTrue(result.All(r => expected.Contains(r)));
            Assert.IsFalse(result.Any(r => !expected.Contains(r)));
        }

        [TestMethod]
        public void fidns_factors_for_100()
        {
            var helper = new FactorsHelper();
            var result = helper.Factors(100);
            var expected = new[] { 2, 4, 5, 10, 20, 25, 50 };
            Assert.IsTrue(result.All(r => expected.Contains(r)));
            Assert.IsFalse(result.Any(r => !expected.Contains(r)));
        }
    }
}
