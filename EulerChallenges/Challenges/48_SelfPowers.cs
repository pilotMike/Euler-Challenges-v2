using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Challenges;

namespace EulerChallenges.Challenges
{
    public class _48_SelfPowers : IChallenge<string>
    {
        public string Run()
        {
            BigInteger val = 0;
            for (int i = 1; i < 1001; i++)
                val += BigInteger.Pow(i, i);
            var text = val.ToString();

            return text.Substring(text.Length - 10);
        }
    }
}
