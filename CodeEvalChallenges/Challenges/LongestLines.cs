using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class LongestLines : IChallenge<string>
    {
        private IEnumerable<string> _lines;
        private int _take;

        public LongestLines(string file)
        {
            var lines = FileHelper.OpenFile(file).ToList();
            _take = int.Parse(lines.First());
            _lines = lines.Skip(1).ToList();
        }

        public LongestLines(IEnumerable<string> lines)
        {
            lines = lines.ToList();
            _take = int.Parse(lines.First());
            _lines = lines.Skip(1).ToList();
        }

        public IEnumerable<string> Run()
        {
            return _lines.OrderByDescending(l => l.Length).Take(_take);
        }
    }
}
