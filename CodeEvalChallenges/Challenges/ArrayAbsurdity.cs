using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class ArrayAbsurdity : IChallenge<string>
    {
        private readonly IEnumerable<IEnumerable<string>> _lines;

        public ArrayAbsurdity(string file)
        {
            _lines = Prep(FileHelper.OpenFile(file));
        }

        public ArrayAbsurdity(IEnumerable<string> input)
        {
            _lines = Prep(input);
        }

        private static IEnumerable<IEnumerable<string>> Prep(IEnumerable<string> lines)
        {
            return from line in lines
                let split = line.Split(';')
                let length = int.Parse(split[0])
                select split[1].Split(',').Take(length);
        }


        public IEnumerable<string> Run()
        {
            return from line in _lines
                let g = line.GroupBy(s => s).First(g => g.Count() > 1)
                select g.Key;
        }
    }
}
