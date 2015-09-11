using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class MinimumCoins : IChallenge<int>
    {
        private readonly IEnumerable<int> _lines;
        private readonly int[] _coins = new[] {5, 3, 1};

        public MinimumCoins(IEnumerable<int>lines)
        {
            _lines = lines;
        }
        public MinimumCoins(IEnumerable<string> lines )
        {
            _lines = lines.Select(int.Parse);
        }
        public MinimumCoins(string file) : this(FileHelper.OpenFile(file))
        {}

        public IEnumerable<int> Run()
        {
            return from line in _lines
                select GetCount(line);
        }

        private int GetCount(int amount)
        {
            int count = 0;
            while (amount > 0)
            {
                int coin = _coins.First(c => amount/c >= 1);
                amount -= coin;
                count++;
            }
            return count;
        }
    }
}
