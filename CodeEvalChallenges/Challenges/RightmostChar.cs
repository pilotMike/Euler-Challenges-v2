using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeEvalChallenges
{
    public class RightmostChar : IChallenge<int>
    {
        private IEnumerable<Tuple<string, string>> _lines;

        public RightmostChar(string file)
        {
            _lines = from line in FileHelper.OpenFile(file)
                let parts = line.Split(new []{','}).ToArray()
                select Tuple.Create(parts[0], parts[1]);
        }
        public IEnumerable<int> Run()
        {
            return from line in _lines
                let index = String.Concat(line.Item1.Reverse()).IndexOf(line.Item2)
                select (index == -1) ? index : line.Item1.Length - index;
        }
    }
}