using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeEvalChallenges
{
    public class SetIntersection : IChallenge<string>
    {
        private IEnumerable<Tuple<string[], string[]>> _lines;

        public SetIntersection(string file)
        {
            _lines = from line in FileHelper.OpenFile(file)
                let lists = line.Split(new []{';'}).ToArray()
                let first = lists[0].Split(new []{','})
                let second = lists[1].Split(new []{','})
                select Tuple.Create(first, second);
        }

        public IEnumerable<string> Run()
        {
            return from l in _lines
                select String.Join(",", l.Item1.Intersect(l.Item2));
        }
    }
}