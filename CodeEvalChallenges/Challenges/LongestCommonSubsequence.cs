using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeEvalChallenges.Challenges
{
    public class LongestCommonSubsequence : IChallenge<string>
    {
        private readonly IEnumerable<Tuple<string, string>> _lines;
        public LongestCommonSubsequence(IEnumerable<string> lines )
        {
            _lines = from line in lines
                let parts = line.Split(';')
                select Tuple.Create(parts[0], parts[1]);
        }
        public LongestCommonSubsequence(string file) : this(FileHelper.OpenFile(file))
        { }

        public IEnumerable<string> Run()
        {
            var matches = from line in _lines
                select new CommonSubsequenceFinder<char>(line.Item1.ToList(), line.Item2.ToList()).FindSequences().OrderByDescending(a => a.Count).FirstOrDefault();
            return matches.Select(match => String.Join("", match));
        }
    }

    public class CommonSubsequenceFinder<T> 
    {
        private readonly IList<T> _item1;
        private readonly IList<T> _item2;
        private int _pA = 0;

        public CommonSubsequenceFinder(IList<T> item1, IList<T> item2)
        {
            _item1 = item1;
            _item2 = item2;
        }

        public IEnumerable<IList<T>> FindSequences()
        {
            foreach (var a0 in _item1)
            {
                var matchFinder = new MatchFinder<T>(_item2);
                var matchingElements = _item1.Skip(_pA).Select(a1 => matchFinder.FindNextMatch(a1)).Where(t => t.Item2 > -1).Select(t => t.Item1);

                _pA++;
                yield return matchingElements.ToList();
            }
        }
    }

    /// <summary>Returns all non-contiguous subsequences between two collections. </summary>
    public class MatchFinder<T> 
    {
        private readonly IList<T> _item2;
        private int _pB = 0;
        private readonly IEqualityComparer<T> _comparer = EqualityComparer<T>.Default;

        public MatchFinder(IList<T> list)
        {
            _item2 = list;
        }

        /// <summary>
        /// Returns a match continuing from the last position in the list, this time for the element passed in. If a match isn't found, 
        /// the Tuple's Item2 property will be -1.
        /// </summary>
        public Tuple<T, int> FindNextMatch(T a)
        {
            var match =
                _item2.Select((e, i) => Tuple.Create(e, i))
                    .Skip(_pB)
                    .FirstOrDefault(t => _comparer.Equals(a, t.Item1));

            if (match != null)
            {
                _pB = match.Item2;
                return match;
            }
            return Tuple.Create(default(T), -1);
        }

    }
}
