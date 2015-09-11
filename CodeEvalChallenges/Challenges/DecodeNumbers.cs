using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class DecodeNumbers :IChallenge<int>
    {
        private IEnumerable<string> _lines;

        public DecodeNumbers(IEnumerable<string> lines)
        {
            this._lines = lines;
        }

        public DecodeNumbers(string file) :this(FileHelper.OpenFile(file))
        {
            
        }
        public IEnumerable<int> Run()
        {
            return from line in _lines
                   let asNumbers = line.Select(c => int.Parse(c.ToString())).ToArray()
                   select Decode(asNumbers);
        }

        private int Decode(int[] line)
        {
            int count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] < 3 && i < line.Length - 1 && line[i + 1] < 7 && line[i + 1] == 0)
                {
                    count++;
                    i++;
                }
                else if (line[i] < 3 && i < line.Length - 1 && line[i + 1] < 7)
                {
                    count += 2;
                    i++;
                }
                else
                    count += 1;
            }
            return count;
        }

    }
}
