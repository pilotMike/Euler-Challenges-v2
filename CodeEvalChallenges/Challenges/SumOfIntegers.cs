using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class SumOfIntegers : IChallenge<int>
    {
        private IEnumerable<string> _lines;

        public SumOfIntegers(IEnumerable<string> lines )
        {
            _lines = lines;
        }
        public IEnumerable<int> Run()
        {
            return from line in _lines
                let numbers = line.Split(',').Select(int.Parse).ToList()
                let greatest = GetGreatest(numbers)
                select greatest;
        }

        private int GetGreatest(IList<int> numbers)
        {
            var dic = numbers.Select((n,i) => Tuple.Create(n,i)).ToDictionary(t => t.Item1, t => numbers.Skip(t.Item2 + 1));
            var max = 0;
            foreach (var pair in dic)
            {
                var otherNumbers = pair.Value.Reverse();
                var sum = pair.Key + pair.Value.Sum();
                var highest = sum;
                foreach (var on in otherNumbers)
                {
                    sum -= on;
                    if (highest < sum) highest = sum;
                }
                if (highest > max) max = highest;
            }
            return max;
        }
    }
}
