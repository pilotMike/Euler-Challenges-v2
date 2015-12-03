
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
	public class NmodM : IChallenge<int>
	{
		private readonly IEnumerable<Tuple<int, int>> _pairs;
		public NmodM(string file) : this(FileHelper.OpenFile(file)
		{}
		
		public NmodM(IEnumerable<string> lines)
		{
			_pairs = lines.Select(line => 
			{
				var split = line.Split(',');
	            return Tuple.Create(int.Parse(split[0]), int.Parse(split[1]));
            }
		}
		
		public Func<int, int, int> Mod = (a,b) => a - (int)(a/b) * b;
		
		public IEnumerable<int> Run()
		{
			return _pairs.Select(pair => Mod(pair.Item1, pair.Item2));
		}
	}
}
