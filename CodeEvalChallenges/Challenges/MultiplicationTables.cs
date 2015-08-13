using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeEvalChallenges.Challenges
{
    public class MultiplicationTables : IChallenge<string>
    {
        public IEnumerable<string> Run()
        {
            return Enumerable.Range(1, 12)
                .Select(x => Enumerable.Range(1, 12).Select(y => x*y).ToList())
                .Select(tempList => String.Join("", tempList.Select(i => i.ToString().PadLeft(4)))).ToList();
        }
    }
}