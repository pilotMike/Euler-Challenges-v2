using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class RemoveCharacters : IChallenge<string>
    {
        private IEnumerable<Tuple<string, char[]>> _lines;

        public RemoveCharacters(string file)
        {
            _lines = Prep(FileHelper.OpenFile(file));
        }

        public RemoveCharacters(IEnumerable<string> input )
        {
            _lines = Prep(input);
        }

        private static IEnumerable<Tuple<string, char[]>> Prep(IEnumerable<string> input)
        {
            return from line in input
                let split = line.Split(',')
                let remove = split[1].Trim().ToCharArray()
                select Tuple.Create(split[0], remove);
        }

        public IEnumerable<string> Run()
        {
            return from line in _lines
                let output = new string(line.Item1.Where(c => !line.Item2.Contains(c)).ToArray())
                select output;

        }
    }
}
