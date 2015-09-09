using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class JollyJumpers : IChallenge<string>
    {
        private IEnumerable<Tuple<int, List<int>>> _lines;

        public JollyJumpers(string file)
        {
            _lines = FileHelper.OpenFile(file).Select(line =>
            {
                var splits = line.Split(' ').Select(int.Parse).ToArray();
                return Tuple.Create(splits[0], splits.Skip(1).ToList());
            });
        }

        public JollyJumpers(IEnumerable<string> input )
        {
            _lines = input.Select(line =>
            {
                var splits = line.Split(' ').Select(int.Parse).ToArray();
                return Tuple.Create(splits[0], splits.Skip(1).ToList());
            });
        }

        public IEnumerable<string> Run()
        {
            return from line in _lines
                let j = IsJolly(line)
                select j ? "Jolly" : "Not jolly";
        }

        private bool IsJolly(Tuple<int, List<int>> line)
        {
            HashSet<int> diffs = new HashSet<int>();
            line.Item2.Aggregate((acc, current) =>
            {
                diffs.Add(Math.Abs(acc - current));
                return current;
            });
            return diffs.Count(n => n > 0 && n < line.Item1) == (line.Item1 - 1);
        }
    }
}
