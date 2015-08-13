using System;
using System.Linq;
using CodeEvalChallenges.Challenges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeEvalChallengesTest
{
    [TestClass]
    public class ReverseWordsTests
    {
        [TestMethod]
        public void Passes()
        {
            var input = new [] { "Hello World", "Hello CodeEval", " ", ""};
            var prog = new ReverseWords(input);
            var result = prog.Run();
            var expected = String.Join(System.Environment.NewLine,
                input.Where(s => !String.IsNullOrWhiteSpace(s)).Reverse());
            Assert.AreEqual(expected, result);
        }
    }
}