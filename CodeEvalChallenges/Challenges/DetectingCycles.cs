using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
        public class CycleDetection
    {
        public IEnumerable<IList<T>> Cycles<T>(IList<T> source)
        {
            var dic = GetRepeatingValues(source);
            int currentIndex = 0;

            while (currentIndex < source.Count)
            {
                var result = GetCycles(dic, currentIndex);
                currentIndex = result.LastIndex;
                if (result.HasResult)
                    yield return result.Cycles;
            }
            yield break;
        }

        private CycleResult<T> GetCycles<T>(Dictionary<T, List<int>> dic, int currentIndex)
        {
            var emptyResult = EmptyResult<T>(currentIndex);
            if (!dic.Any(pair => pair.Value.Contains(currentIndex))) return emptyResult;

            var key = dic.First(pair => pair.Value.Contains(currentIndex)).Key;
            var values = dic[key];

            if (values.Last() == currentIndex) return emptyResult;

            var indexOf = values.IndexOf(currentIndex);
            var range = values[indexOf + 1] - values[indexOf];

            var potentialCycles = new List<T>();
            var lastIndex = currentIndex;

            for (int i = currentIndex; i < currentIndex + range; i++)
            {
                if (!dic.Any(pair => pair.Value.Contains(i))) break;
                potentialCycles.Add(dic.First(pair => pair.Value.Contains(i)).Key);
                lastIndex++;
            }

            var result = new CycleResult<T>() { HasResult = true, Cycles = potentialCycles, LastIndex = lastIndex, CycleStartIndex = currentIndex, Range = potentialCycles.Count };
            return result;
        }

        private static CycleResult<T> EmptyResult<T>(int currentIndex)
        {
            return new CycleResult<T>() { HasResult = false, LastIndex = currentIndex + 1 };
        }

        private Dictionary<T, List<int>> GetRepeatingValues<T>(IList<T> source)
        {
            var tups = source.Select((item, i) => Tuple.Create(item, i));
            var dic = new Dictionary<T, List<int>>();
            foreach (var tuple in tups)
            {
                if (!dic.ContainsKey(tuple.Item1)) dic.Add(tuple.Item1, new List<int> { tuple.Item2 });
                else dic[tuple.Item1].Add(tuple.Item2);
            }
            dic = dic.Where(pair => pair.Value.Count > 1).ToDictionary(pair => pair.Key, pair => pair.Value);
            return dic;
        }
    }

    class CycleResult<T>
    {
        public bool HasResult { get; set; }
        public List<T> Cycles { get; set; }
        /// <summary>
        /// Used for incrementing the outermost loop.
        /// </summary>
        public int LastIndex { get; set; }
        public int CycleStartIndex { get; set; }
        public object Range { get; set; }
    }
}
