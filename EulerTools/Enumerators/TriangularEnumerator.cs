using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Formulas;

namespace EulerTools.Enumerators
{
    public class TriangularEnumerator : IEnumerable<long>
    {
        public IEnumerator<long> GetEnumerator()
        {
            int x = 1;
            while (true)
            {
                checked { x++; }
                if (x % 1000 == 0)
                   Console.WriteLine(x);
                yield return TriangularFormulas.TriangularNumber(x);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //public class BigTriangularEnumerator : IEnumerable<BigInteger>
    //{
    //    public IEnumerator<BigInteger> GetEnumerator()
    //    {
    //        uint x = 1;
    //        while (true)
    //        {
    //            checked { x++; }
    //            if (x % 1000 == 0)
    //                Console.WriteLine(x);
    //            yield return TriangularFormulas.TriangularNumberBig(x);
    //        }
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }
    //}
}
