using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class BalancedSmileys : IChallenge<string>
    {
        private readonly IEnumerable<string> _lines;

        public BalancedSmileys(string file) : this (FileHelper.OpenFile(file))
        { }

        public BalancedSmileys(IEnumerable<string> lines )
        {
            _lines = lines;
        }
        public IEnumerable<string> Run()
        {
            //remove all characters, spaces and smilies. Unfortunately, couldn't figure out
            //anything between valid parens, but those would be left over, so remove those
            // in a second regex. If it's valid, then the string will be empty.
            return from line in _lines
                let remainder =
                    Regex.Replace(Regex.Replace(line, @"[A-z]\:*\s*|\([A-z:\(\)]\)|\:\)|\:\(", String.Empty),
                        @"\(\)", String.Empty)
                select remainder.Length == 0 ? "YES" : "NO";

        }
    }
}
