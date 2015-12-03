using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class UriComparison : IChallenge<string>
    {
        private IEnumerable<Tuple<Uri, Uri>> _uriPairs;

        public UriComparison(IEnumerable<string> lines)
        {
            _uriPairs = lines.Select(line =>
            {
                var split = line.Split(';');
                return Tuple.Create(new Uri(split[0]), new Uri(split[1]));
            });
        }
        public UriComparison(string file) :this(FileHelper.OpenFile(file))
        {
            
        }
        public IEnumerable<string> Run()
        {
            throw new NotImplementedException();
        }
    }
}
