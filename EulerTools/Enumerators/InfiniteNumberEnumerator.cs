using System;
using System.Collections;
using System.Collections.Generic;

namespace EulerTools.Enumerators
{
    public class InfiniteNumberEnumerator : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            int x = 0;
            while (true)
            {
                checked { x++; }
                yield return x;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
