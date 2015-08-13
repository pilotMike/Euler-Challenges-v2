using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Numbers;

namespace EulerTools.Enumerators
{
    public class PentagonalEnumerator : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            int x = 1;
            while (true)
            {
                x++;
                yield return PentagonalFormulas.PentagonalFormula(x);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
