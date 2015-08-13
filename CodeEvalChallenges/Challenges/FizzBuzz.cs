using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeEvalChallenges.Challenges
{
    public class FizzBuzz : IChallenge<string>
    {
        private IEnumerable<string> _lines;
        public FizzBuzz(string file)
        {
            _lines = FileHelper.OpenFile(file);
        }

        public FizzBuzz(IEnumerable<string> lines)
        {
            _lines = lines;
        }


        public IEnumerable<string> Run()
        {
            var a = from l in _lines
                let parts = l.Split(new[] {' '}).Select(part => Convert.ToInt32(part)).ToArray()
                let tup = Tuple.Create(parts[0], parts[1], parts[2])
                let range = Enumerable.Range(1, tup.Item3)
                let newLine = range.Select((int n) =>
                {
                    if (n % tup.Item1 == 0 && n % tup.Item2 == 0) return "FB";
                    if (n % tup.Item1 == 0) return "F";
                    if (n % tup.Item2 == 0) return "B";
                    return n.ToString();
                })
                select string.Join(" ", newLine);
            return a;
        }
        
    }
}