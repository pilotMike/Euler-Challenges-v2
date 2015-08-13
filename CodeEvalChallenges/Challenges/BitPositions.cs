using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class BitPositions : IChallenge<string>
    {
        private IEnumerable<Tuple<int, int, int>> _lines;

        public BitPositions(string file)
        {
            _lines = from line in FileHelper.OpenFile(file)
                     let split = line.Split(new[] {','}).Select(int.Parse).ToList()
                     select Tuple.Create(split[0], split[1], split[2]);
        }

        public BitPositions(IEnumerable<Tuple<int, int, int>> input )
        {
            _lines = input;
        }

        public IEnumerable<string> Run()
        {
            return from l in _lines
                let binary = Convert.ToString(l.Item1, 2)
                select (binary[binary.Length - l.Item2] == binary[binary.Length - l.Item3]) ? "true" : "false";
        }
    }
}
