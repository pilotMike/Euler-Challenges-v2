using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class MthToLastElement : IChallenge<string>
    {
        private readonly IEnumerable<string> _lines;

        public MthToLastElement(string file)
        {
            _lines = FileHelper.OpenFile(file);
        }

        public MthToLastElement(string[] input)
        {
            _lines = input;
        }

        public IEnumerable<string> Run()
        {
            return from line in _lines
                let split = line.Split(' ').Reverse().ToArray()
                let position = int.Parse(split.First())
                where position <= split.Length
                select split.ElementAt(position);
        }
    }
}
