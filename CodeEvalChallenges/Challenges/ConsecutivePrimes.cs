using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class ConsecutivePrimes : IChallenge<int>
    {
        private IEnumerable<int> _lines;

        public ConsecutivePrimes(IEnumerable<string> lines)
        {
            _lines = lines.Select(int.Parse);
        }
        public ConsecutivePrimes(string file) :this(FileHelper.OpenFile(file))
        {
            
        }
        public IEnumerable<int> Run()
        {
            throw new NotImplementedException();
        }
    }
}
