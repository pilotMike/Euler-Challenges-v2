using System.Collections.Generic;
using System.Linq;

namespace CodeEvalChallenges.Challenges
{
    public class SumOfDigits : IChallenge<int>
    {
        private IEnumerable<string> _lines;
        public SumOfDigits(string file)
        {
            _lines = FileHelper.OpenFile(file);
        }

        public SumOfDigits(IEnumerable<string> lines)
        {
            _lines = lines;
        }

        public IEnumerable<int> Run()
        {
            return from line in _lines
                select line.Select(c => int.Parse(c.ToString())).Sum();
        }
    }
}