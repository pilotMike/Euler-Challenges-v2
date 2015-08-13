using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeEvalChallenges.Challenges
{
    public class UniqueElements : IChallenge<string>
    {
        private IEnumerable<string> _lines;

        public UniqueElements(string file)
        {
            _lines = FileHelper.OpenFile(file);
        }
        public IEnumerable<string> Run()
        {
            return from line in _lines
                let ints = line.Split(',').Distinct()
                select String.Join(",", ints);
        }
    }
}