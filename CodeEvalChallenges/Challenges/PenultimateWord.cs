using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class PenultimateWord : IChallenge<String>
    {
        private readonly IEnumerable<string> _lines;

        public PenultimateWord(IEnumerable<string> lines )
        {
            _lines = lines;
        }
        public PenultimateWord(string file) :this(FileHelper.OpenFile(file))
        {
            
        }
        public IEnumerable<string> Run()
        {
            return _lines.Select(l => l.Split(' ').Reverse().Skip(1).First());
        }
    }
}
