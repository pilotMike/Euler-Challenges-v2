using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class StringRotation : IChallenge<string>
    {
        private readonly IEnumerable<Tuple<string, string>> _lines;

        public StringRotation(IEnumerable<string> lines)
        {
            _lines = lines.Select(line => line.Split(',')).Select(split => Tuple.Create(split[0], split[1]));
        }

        public StringRotation(string file) :this(FileHelper.OpenFile(file))
        {
        }

        public IEnumerable<string> Run()
        {
            return from line in _lines
                select (IsRotation(line.Item1, line.Item2)) ? "True" : "False";
        }

        private bool IsRotation(string s1, string s2)
        {
            var indexes = s1.Select((c, i) => Tuple.Create(c, i)).Where(t => t.Item1 == s2[0]).Select(t => t.Item2);

            return indexes.Select(index => Rotate(s1, index)).Any(rotation => rotation == s2);
        }

        private string Rotate(string s1, int index)
        {
            return s1.Substring(index) + s1.Substring(0, index);
        }
    }
}
