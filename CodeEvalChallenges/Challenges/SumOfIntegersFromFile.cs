using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeEvalChallenges.Challenges
{
    public class SumOfIntegersFromFile : IChallenge<int>
    {
        private IEnumerable<string> _lines;

        public SumOfIntegersFromFile(string file)
        {
            _lines = FileHelper.OpenFile(file);
        }
        public IEnumerable<int> Run()
        {
            return new []{ _lines.Select(int.Parse).Sum()};
        }
    }
}