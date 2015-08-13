using System.Collections.Generic;

namespace EulerTools.Numbers
{
    public class FactorsHelper
    {
        public IEnumerable<int> Factors(int n)
        {
            for (int i = 2; i < n/i; i++)
                if (n % i == 0)
                {
                    yield return i;
                    yield return n / i;
                }
        }
    }
}
