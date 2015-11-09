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

        [TestMethod]
        public void CashRegister()
        {
            var input = new[] { "15.94;16.00", "17;16", "35;35", "45;50",".01;.05" };
            var expected = new[] { "NICKEL,PENNY", "ERROR", "ZERO", "FIVE", "PENNY,PENNY,PENNY,PENNY" };
            var result = new CashRegister(input).Run();
            AssertExtensions.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReverseGroups()
        {
            var input = new [] {"1,2,3,4,5;2", "1,2,3,4,5;3"};
            var expected = new[] {"2,1,4,3,5", "3,2,1,4,5"};
            var result = new ReverseGroups(input).Run();
            AssertExtensions.AreEqual(expected, result);
        }

        [TestMethod]
        public void DecodeNumbers()
        {
            var input = new[] {"12", "123", "26", "126"};
            var expected = new[] {2, 3, 2, 3};
            var result = new DecodeNumbers(input).Run();
            AssertExtensions.AreEqual(expected, result);
        }

        [TestMethod]
        public void MinimumCoins()
        {
            var input = new[] {11, 20};
            var expected = new[] {3, 4};
            var result = new MinimumCoins(input).Run();
            AssertExtensions.AreEqual(expected, result);
        }

        [TestMethod]
        public void OperationParser()
        {
            var input = "* + 2 3 4";
            var result = Operation.Parse(input);
            Assert.IsTrue(result.Operations.Contains(Operator.Mult));
            Assert.IsTrue(result.Operations.Contains(Operator.Add));
        }

        [TestMethod]
        public void OperationRunnerTest()
        {
            var op = Operation.Parse("* + 2 3 4");
            var result = OperationRunner.Run(op);
            var expected = 20;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OperationRunnerTest1()
        {
            var op = Operation.Parse("/ + 10 2 4");
            var result = OperationRunner.Run(op);
            var expected = 9;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void OperationRunnerTest_negative_number()
        {
            var op = Operation.Parse("+ -1 2");
            var result = OperationRunner.Run(op);
            var expected = 1;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StringRotation()
        {
            var input = new[] {"Hello,lloHe", "Basefont,tBasefon"};
            var expected = new[] {"True", "True"};
            var result = new StringRotation(input).Run();
            AssertExtensions.AreEqual(expected, result);
        }

        [TestMethod]
        public void StringList()
        {
            var input = new[] {"1,aa", "2,ab", "3,pop"};
            var expected = new[] {"a", "aa,ab,ba,bb", "ooo,oop,opo,opp,poo,pop,ppo,ppp"};
            var result = new StringList(input).Run();
            AssertExtensions.AreEqual(expected, result);
        }

        [TestMethod]
        public void StackImplementation()
        {
            var input = new[] { "1 2 3 4", "10 -2 3 4" };
            var expected = new[] { "4 2", "4 -2" };
            var result = new StackImplementation(input).Run();
            AssertExtensions.AreEqual(expected, result);
        }

        [TestMethod]
        public void LongestCommonSubsequence()
        {
            var input = new[] {"XMJYAUZ;MZJAWXU"};
            var expected = "MJAU";
            var result = new LongestCommonSubsequence(input).Run().First();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StringSearchingRegMakesRegex()
        {
            var input = "C*Eval";
            var expected = "C[a-Z]*Eval";
            var result = StringSearching.GetRegString(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StringSearchingRegDoesntMakeRegex()
        {
            var input = @"C\*Eval";
            var expected = @"C\*Eval";
            var result = StringSearching.GetRegString(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void StringSearchingTest()
        {
            var input = new[] {"Hello,ell", "This is good, is", "CodeEval,C*Eval", "Old,Young"};
            var expected = new[] {"true", "true", "true", "false"};
            var result = new StringSearching(input).Run();
            AssertExtensions.AreEqual(expected,result);
        }

        [TestMethod]
        public void sudoku_grid_parses_grid_from_data()
        {
            var input = new[] {"4;1,4,2,3,2,3,1,4,4,2,3,1,3,1,4,2", "4;2,1,3,2,3,2,1,4,1,4,2,3,2,3,4,1"};
            var boxes = input.Select(line => new Sudoku().ParseGrid(line)).ToList();
        }

        [TestMethod]
        public void sudoku_grid_checks_validity()
        {
            var input = new[] { "4;1,4,2,3,2,3,1,4,4,2,3,1,3,1,4,2", "4;2,1,3,2,3,2,1,4,1,4,2,3,2,3,4,1" };
            var expected = new[] {"True", "False"};
            var results = new Sudoku(input).Run();
            AssertExtensions.AreEqual(expected, results);
        }

        [TestMethod]
        public void sudoku_box_parses_box()
        {
            var inputText = "4;1,4,2,3,2,3,1,4,4,2,3,1,3,1,4,2";
            var inputDim = int.Parse(inputText[0].ToString());
            var inputNums = inputText.Split(';')[1].Split(',').Select(int.Parse).ToArray();
            var grid = SudokuGrid.ParseGrid(inputDim, inputNums);
            var firstBox = grid.Boxes.First();
            var valid = firstBox.IsValid;

            var expectedNums = new[] {1, 4, 2, 3};
            Assert.IsTrue(expectedNums.Select((n,i) => firstBox.Numbers[i] == n).All(b => b));
            AssertExtensions.AreEqual(expectedNums, firstBox.Numbers);
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void sudoku_box_parses_second_box()
        {
            var inputText = "4;1,4,2,3,2,3,1,4,4,2,3,1,3,1,4,2";
            var inputDim = int.Parse(inputText[0].ToString());
            var inputNums = inputText.Split(';')[1].Split(',').Select(int.Parse).ToArray();
            var grid = SudokuGrid.ParseGrid(inputDim, inputNums);
            var box = grid.Boxes.ElementAt(1);

            var expectedNums = new[] {2, 3, 1, 4};
            AssertExtensions.AreEqual(expectedNums, box.Numbers);
        }
    }
}
