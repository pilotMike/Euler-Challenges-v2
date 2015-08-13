using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class NumberOfOnes : IChallenge<string>
    {
        private IEnumerable<string> _lines;

        public NumberOfOnes(string file)
        {
            _lines = FileHelper.OpenFile(file);
        }

        public NumberOfOnes(IEnumerable<string> input)
        {
            _lines = input;
        }

        public IEnumerable<string> Run()
        {
            return from line in _lines.Select(line => Convert.ToString(int.Parse(line), 2))
                select line.Count(c => c == '1').ToString();
        }
    }
}
