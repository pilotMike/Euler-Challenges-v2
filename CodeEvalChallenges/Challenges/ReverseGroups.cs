using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class ReverseGroups : IChallenge<string>
    {
        private IEnumerable<IEnumerable<Tuple<List<int>, int>>> _lines;

        public ReverseGroups(IEnumerable<string> lines)
        {
            _lines = lines.Select(line =>
            {
                var parts = line.Split(';');
                var size = int.Parse(parts[1]);
                return from n in parts[0].Split(',').Select(int.Parse).Select((x,i) => new { x, i })
                        group n.x by n.i / size into g
                        select Tuple.Create(g.ToList(), size);
            });
        }
        public IEnumerable<string> Run()
        {
            return from line in _lines
                let r = line.SelectMany(l => 
                {
                    if (l.Item1.Count%l.Item2==0)
                        l.Item1.Reverse();
                    return l.Item1;
                })
                select String.Join(",", r);
        }
    }
}
