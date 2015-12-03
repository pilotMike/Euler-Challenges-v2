using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class Endianness : IChallenge<string>
    {
        public IEnumerable<string> Run()
        {
            yield return BitConverter.IsLittleEndian ? "LittleEndian" : "BigEndian";
        }
    }
}
