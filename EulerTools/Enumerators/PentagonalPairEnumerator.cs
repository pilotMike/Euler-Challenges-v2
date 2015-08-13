using System;
using System.Collections;
using System.Collections.Generic;
using EulerTools.Numbers;

namespace EulerTools.Enumerators
{
    public class PentagonalPairEnumerator : IEnumerable<Tuple<int, int>>
    {
        public IEnumerator<Tuple<int, int>> GetEnumerator()
        {
            int topNumber = 1;
            int subNumber = 1;

            while (true)
            {
                if (subNumber == 1)
                {
                    topNumber++;
                    subNumber = topNumber - 1;
                }
                else
                {
                    subNumber--;
                }
                int pentagonalFirst = PentagonalFormulas.PentagonalFormula(topNumber);
                int pentagonalSecond = PentagonalFormulas.PentagonalFormula(subNumber);
                yield return new Tuple<int, int>(pentagonalFirst, pentagonalSecond);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
