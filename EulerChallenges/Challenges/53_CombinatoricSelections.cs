using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Challenges;
using EulerTools.Formulas;
using EulerTools.Numbers;

namespace EulerChallenges.Challenges
{
    public class _53_CombinatoricSelections : IChallenge<int>
    {
        private readonly uint _countGreaterThan;
        private static FactorialHelper _fHelper;

        public _53_CombinatoricSelections() : this (1000000)
        { }

        public _53_CombinatoricSelections(int countGreaterThan)
        {
            _countGreaterThan = (uint)countGreaterThan;
            _fHelper = new FactorialHelper();
        }

        public int Run()
        {
            return (from n1 in ParallelEnumerable.Range(23, 100)
                    from r1 in Enumerable.Range(1, n1)
                    where CombinatoricsCount(n1, r1) > _countGreaterThan
                    select n1).Count();
        }

        public ulong CombinatoricsCount(int n, int r)
        {
            var result = _fHelper.GetFactorial(n)/
                   (_fHelper.GetFactorial(r)*_fHelper.GetFactorial(n - r));
            return result;
        }

    }

    
}
