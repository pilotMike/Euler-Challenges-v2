using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Challenges;
using EulerTools.Numbers;

namespace EulerChallenges.Challenges
{
    public class _55_LychrelNumbers : IChallenge<int>
    {
        private readonly ConcurrentDictionary<int, int> _dic = new ConcurrentDictionary<int, int>();
        private readonly int _limit;

        public _55_LychrelNumbers(int limit)
        {
            _limit = limit;
        }
        public _55_LychrelNumbers() : this(10000)
        {
        }
        public int Run()
        {
            return ParallelEnumerable.Range(10, _limit).Where(IsLychrel).Count();
        }

        /// <summary>
        /// A lychrel number is a number that, when reversed and added to itself repeatedly,
        /// never produces a palindrome.
        /// </summary>
        public bool IsLychrel(int n)
        {
            if (_dic.ContainsKey(n))
            {
                if (_dic[n] == -1) return true; // -1 means it doesn't become a palindrome
                if (_dic[n] > 0) return false;
                // if the value > 0, then the count has been determined for that number
            }

            int count = 0;
            BigInteger num = n;
            for (int i = 0; i < 50; i++) // up to 50 iterations
            {
                var rev = DigitHelper.Reverse(num);
                num += rev;
                var split = DigitHelper.SplitDigits(num);
                if (!PalindromeHelper.IsPalindrome(split))
                {
                    // try again
                    count++;
                }
                else
                {
                    _dic[n] = count;
                    return false;
                    // do something with dictionary
                }
            }

            _dic[n] = -1;
            return true;
        }
    }
}
