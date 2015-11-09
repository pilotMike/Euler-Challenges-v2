using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class StringSearching : IChallenge<string>
    {
        private readonly IEnumerable<Tuple<string, string>> _lines;

        public StringSearching(IEnumerable<string> lines)
        {
            _lines = lines.Select(line =>
            {
                var parts = line.Split(',');
                return Tuple.Create(parts[0].Trim(), parts[1].Trim());
            });
        }
        public StringSearching(string file) :this(FileHelper.OpenFile(file))
        {
        }

        public IEnumerable<string> Run()
        {
            return from line in _lines
                let regString = GetRegString(line.Item2) 
                select Regex.Match(line.Item1, regString).Success ? "true" : "false";
        }

        public static string GetRegString(string line)
        {
            var indexes = line.Select((c, i) => Tuple.Create(c, i))
                .Where(t => t.Item1 == '*')
                .Select(t => t.Item2)
                .OrderByDescending(i => i);
            foreach (var index in indexes.Where(i => i>0))
            {
                if (line[index - 1] != '\\')
                    line = line.Remove(index, 1).Insert(index, "[A-z]*");
            }
            return line;
        }
    }
}
