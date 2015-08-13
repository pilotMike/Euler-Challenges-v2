using System;
using System.Collections.Generic;
using System.Linq;
using Facet.Combinatorics;

namespace CodeEvalChallenges.Challenges
{
    public class StringPermutations : IChallenge<string>
    {
        private IEnumerable<string> _lines;

        public StringPermutations(string file)
        {
            _lines = FileHelper.OpenFile(file);
        }

        public StringPermutations(IEnumerable<string> lines)
        {
            _lines = lines;
        }

        public IEnumerable<string> Run()
        {
            return from l in _lines
                let perms = new Permutations<char>(l.ToArray())
                let linePerms = from p in perms select String.Join("", p)
                select String.Join(",", linePerms);
        }
    }
}