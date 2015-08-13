using System;
using System.Text;
using System.Collections.Generic;
using EulerTools.Primes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EulerToolsTests.Numbers
{
    /// <summary>
    /// Summary description for PrimeCalculatorTests
    /// </summary>
    [TestClass]
    public class PrimeCalculatorTests
    {
        private const int iters = 500000;

        //1.391
        //[TestMethod]
        //public void speed_test_when_not_adding_to_list()
        //{
        //    var pc = new PrimeCalculator();
        //    for (int i = 0; i < iters; i++)
        //    {
        //        pc.IsPrime(i, false);
        //    }
        //    Assert.IsTrue(true);
        //}

        ////22.019
        //[TestMethod]
        //public void speed_test_when_adding_to_list()
        //{
        //    var pc = new PrimeCalculator();
        //    for (int i = 0; i < iters; i++)
        //    {
        //        pc.IsPrime(i, true);
        //    }
        //    Assert.IsTrue(true);
        //}

        //// .477
        //[TestMethod]
        //public void brute_force_speed_test()
        //{
        //    var pc = new PrimeCalculator();
        //    for (int i = 0; i < iters; i++)
        //    {
        //        pc.IsPrime(i, false);
        //    }
        //    Assert.IsTrue(true);
        //}

        //// .445
        //[TestMethod]
        //public void is_prime_brute()
        //{
        //    var pc = new PrimeCalculator();
        //    for (int i = 0; i < iters; i++)
        //    {
        //        pc.IsPrimeBrute(i);
        //    }
        //    Assert.IsTrue(true);
        //}

        ////2.155
        //[TestMethod]
        //public void Parallel_Primes_speed_test()
        //{
        //    var pc = new PrimeCalculator();
        //    pc.GetPrimesUpToParallel(iters);
        //    Assert.IsTrue(true);
        //}

        //2.546
        [TestMethod]
        public void speed_test_getting_primes()
        {
            var pc = new PrimeCalculator();
            pc.GetPrimesUpTo(iters);
            Assert.IsTrue(true);
        }

        // incomplete
        //[TestMethod]
        //public void speed_test_getting_primes_parallel()
        //{
        //    var pc = new PrimeCalculator();
        //    pc.GetPrimesUpToParallel(iters);
        //    Assert.IsTrue(true);
        //}

        //// 3.281
        //[TestMethod]
        //public void speed_test_is_prime_parallel()
        //{
        //    var pc = new PrimeCalculator();
        //    for (int i = 0; i < iters; i++)
        //    {
        //        pc.IsPrimeParallel(i);
        //    }
        //    Assert.IsTrue(true);
        //}

        //// 2:22.035
        //[TestMethod]
        //public void primes_speed_test_parallel_with_collection()
        //{
        //    var pc = new PrimeCalculator();
        //    for (int i = 0; i < iters; i++)
        //    {
        //        pc.IsPrimeParallel_StorePrimes(i);
        //    }
           
        //    Assert.IsTrue(true);
        //}
    }
}
