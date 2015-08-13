using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class HighestScore : IChallenge<string>
    {
        private IEnumerable<IEnumerable<int[]>> _lines;

        public HighestScore(string input)
        {
            _lines = FileHelper.OpenFile(input)
                .Select(l => l.Split('|').Select(entries =>entries.Split(' ').Select(int.Parse).ToArray()));
        }

        public HighestScore(IEnumerable<string> input)
        {
            _lines = input.Select(l => l.Split('|').Select(entries => entries.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()));
        }

        public IEnumerable<string> Run()
        {
            return from line in _lines
                let maxB = line.SelectMany(section => section.Select((s, i) => Tuple.Create(s, i)))
                let grouped = from m in maxB group m by m.Item2 into g select g
                let maxes = from g in grouped select g.Max(item => item.Item1)
                select String.Join(" ", maxes);

        }
    }
}
