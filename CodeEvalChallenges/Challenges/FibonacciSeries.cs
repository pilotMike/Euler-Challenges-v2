using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Fibonacci;

namespace CodeEvalChallenges.Challenges
{
    public class FibonacciSeries : IChallenge<int>
    {
        private readonly IEnumerable<int> _terms;

        public FibonacciSeries(string file) : this (FileHelper.OpenFile(file))
        {}

        public FibonacciSeries(IEnumerable<string> lines)
        {
            _terms = lines.Select(int.Parse);
        }

        public FibonacciSeries(IEnumerable<int> lines)
        {
            _terms = lines;
        }

        public IEnumerable<int> Run()
        {
            return _terms.Select(FibonacciCalculator.ToNthTerm);
        }
    }

}
