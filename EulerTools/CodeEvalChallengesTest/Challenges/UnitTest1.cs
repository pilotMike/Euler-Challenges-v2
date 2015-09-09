using System;
using System.Linq;
using CodeEvalChallenges.Challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayAbsurdity = CodeEvalChallenges.Challenges.ArrayAbsurdity;
using LongestLines = CodeEvalChallenges.Challenges.LongestLines;
using MthToLastElement = CodeEvalChallenges.Challenges.MthToLastElement;
using RemoveCharacters = CodeEvalChallenges.Challenges.RemoveCharacters;

namespace CodeEvalChallengesTest.Challenges
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PrimePalindromeTest()
        {
            var prog = new PrimePalindrome();
            var result = prog.Run();
            var expected = 929;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FizzBuzzTest()
        {
            //var input = new[] {"1 2 F 4 B F 7 8 F B"};
            var input = new string[] {"3 5 10"};
            var expected = "1 2 F 4 B F 7 8 F B";
            var prog = new FizzBuzz(input);
            var result = prog.Run().First();
            //var expected = "1 F 3 F 5 F B F 9 F 11 F 13 FB 15";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FizzBuzzTest_with_multiple_inputs()
        {
            var input = new string[] {"3 5 10", "2 7 15"};
            var expected = new string[] {"1 2 F 4 B F 7 8 F B", "1 F 3 F 5 F B F 9 F 11 F 13 FB 15"};
            var prog = new FizzBuzz(input);
            var result = prog.Run().ToList();
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        //[TestMethod]
        //public void MultiplesOfaNumberTest()
        //{
        //    var input = new[] {"13,8", "17,16"};
        //    var expected = new[] {"16", "32"};
        //    var prog = new MultiplesOfaNumber(input);
        //    var result = prog.Run().ToList();
        //    for (int i = 0; i < result.Count; i++)
        //    {
        //        Assert.AreEqual(int.Parse(expected[i]), result[i]);
        //    }
        //}

        [TestMethod]
        public void BitPositionsTest()
        {
            var input = new[] {Tuple.Create(86, 2, 3), Tuple.Create(125, 1, 2)};
            var expected = new[] {"true", "false"};
            var prog = new BitPositions(input);
            var result = prog.Run().ToList();
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void SumOfDigitsTest()
        {
            var input = new[] {"23", "496"};
            var expected = new[] {"5", "19"};
            var result = new SumOfDigits(input).Run().ToList();
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i].ToString());
            }
        }

        [TestMethod]
        public void StringPermutationsTest()
        {
            var input = new[] {"hat", "abc", "Zu6"};
            var expected = new[] {"aht,ath,hat,hta,tah,tha", "abc,acb,bac,bca,cab,cba", "6Zu,6uZ,Z6u,Zu6,u6Z,uZ6"};
            var prog = new StringPermutations(input);
            var result = prog.Run().ToList();
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void LongestLines()
        {
            var input = new[] {"2", "Hello World", "CodeEval", "Quick Fox", "A", "San Francisco"};
            var prog = new LongestLines(input);
            var result = prog.Run().ToList();
            var expected = new[] {"San Francisco", "Hello World"};
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        private double expand(double num, int pow)
        {
            return Math.Pow(num, pow)/pow;
        }
        public void test()
        {
            var nums = new[] {0, 1};
            var result = nums.Select((n, index) => Enumerable.Range(1, index).Select(i => expand(n, i)).Sum() + 1);
        }

        [TestMethod]
        public void HighestNumbers()
        {
            var input = new[]
            {
                "72 64 150 | 100 18 33 | 13 250 -6", 
                "10 25 -30 44 | 5 16 70 8 | 13 1 31 12",
                "100 6 300 20 10 | 5 200 6 9 500 | 1 10 3 400 143"
            };
            var expected = new[] {"100 250 150", "13 25 70 44", "100 200 300 400 500"};
            var prog = new HighestScore(input);
            var result = prog.Run().ToArray();
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }

        [TestMethod]
        public void MthToLast()
        {
            var input = new[] {"a b c d 4", "e f g h 2"};
            var expected = new[] {"a", "g"};
            var prog = new MthToLastElement(input);
            var result = prog.Run();
            AssertExtensions.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveCharactersTest()
        {
            var input = new[] {"how are you, abc", "hello world, def"};
            var expected = new[] {"how re you", "hllo worl"};
            var result = new RemoveCharacters(input).Run();
            AssertExtensions.AreEqual(expected, result);
        }

        [TestMethod]
        public void NumberOfOnesTest()
        {
            var input = new[] {"10", "22", "56"};
            var expected = new[] {"2", "3", "3"};
            var result = new NumberOfOnes(input).Run();
            AssertExtensions.AreEqual(expected,result);
        }

        [TestMethod]
        public void ArrayAbsurdity()
        {
            var input = new[] {"5;0,1,2,3,0", "20; 0,1,10,3,2,4,5,7,6,8,11,9,15,12,13,4,16,18,17,14"};
            var expected = new[] {"0", "4"};
            var result = new ArrayAbsurdity(input).Run();
            AssertExtensions.AreEqual(expected,result);
        }

        [TestMethod]
        public void LowestCommonAncestorTest()
        {
            var input = new[] {"8 52", "3 29"};
            var expected = new[] {"30", "8"};
            var result = new CodeEvalChallenges.Challenges.LowestCommonAcestor(input).Run();
            AssertExtensions.AreEqual(expected, result);
        }

        [TestMethod]
        public void SumOfIntegersTest()
        {
            var input = new[] {"-10,2,3,-2,0,5,-15", "2,3,-2,-1,10"};
            var expected = new[] {8,12};
            var result = new SumOfIntegers(input).Run();
            AssertExtensions.AreEqual(expected, result);
        }

        [TestMethod]
        public void JollyJumpers()
        {
            var input = new[] {"4 1 4 2 3", "3 7 7 8", "9 8 9 7 10 6 12 17 24 38"};
            var expected = new[] {"Jolly", "Not jolly", "Not jolly"};
            var result = new JollyJumpers(input).Run();
            AssertExtensions.AreEqual(expected, result);
        }
    }
}
