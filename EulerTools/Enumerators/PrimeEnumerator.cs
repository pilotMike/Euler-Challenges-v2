using System.Collections;
using System.Collections.Generic;
using EulerTools.Primes;

namespace EulerTools.Enumerators
{
	public class PrimeEnumerator : IEnumerable<int>
	{
		public IEnumerator<int> GetEnumerator()
		{
			int x = 1;
			while (true)
			{
				checked { x++; }
				if (PrimeCalculator.IsPrime(x))
					yield return x;
			}
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}