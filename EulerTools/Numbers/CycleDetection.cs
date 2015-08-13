using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Numbers
{
    public class CycleDetection
    {
        public static IEnumerable<T> FirstCycle<T>(IList<T> source)
        {
            if (source == null) throw new ArgumentException("source");
            // ReSharper disable once UseNameofExpression
            if (!source.Any()) throw new ArgumentException("sequence is empty", "source");


            T tortoise, hare;
            int tPos = 0;
            int hPos = 1;
            tortoise = source[tPos];
            hare = source[hPos];
            

            while (!tortoise.Equals(hare))
            {
                tPos++;
                hPos += 2;
                tortoise = source[tPos];
                hare = source[hPos];
            }

            int firstRepPos = 0;








            //int stepsTaken = 1;
            //int stepLimit = 2;

            //int returnIndexStart = 0;
            //int totalStepsTaken = 1;

            //T hare, tourtise;
            //hare = tourtise = source.First();

            //while (totalStepsTaken != source.Count)
            //{
            //    hare = source[totalStepsTaken];

            //    if (hare.Equals(tourtise))
            //        return source.Skip(returnIndexStart).Take(totalStepsTaken - returnIndexStart);

            //    stepsTaken++;
            //    totalStepsTaken++;

            //    if (stepsTaken == stepLimit)
            //    {
            //        returnIndexStart += stepsTaken;
            //        stepsTaken = 0;
            //        stepLimit *= 2;
            //        tourtise = hare;
            //    }
            //}

            return new T[] {};
        }

        ///Finds the first common node between two non-cyclical linked lists.
        ///All lists are treated as if they end with a null node.
        ///The null node is treated as a valid node.
        public static Link<T> FindEarliestIntersection<T>(this Link<T> h0, Link<T> h1)
        {
            // find *any* common node, and the distances to it
            var node = new[] { h0, h1 };
            var dist = new[] { 0, 0 };
            var stepSize = 1;
            while (node[0] != node[1])
            {
                // advance each node progressively farther, watching for the other node
                foreach (var i in Enumerable.Range(0, 2))
                {
                    foreach (var repeat in Enumerable.Range(0, stepSize))
                    {
                        if (node[i] == null) break;
                        if (node[0] == node[1]) break;
                        node[i] = node[i].Next;
                        dist[i] += 1;
                    }
                    stepSize *= 2;
                }
            }

            // align heads to be an equal distance from the first common node
            var r = dist[1] - dist[0];
            while (r < 0)
            {
                h0 = h0.Next;
                r += 1;
            }
            while (r > 0)
            {
                h1 = h1.Next;
                r -= 1;
            }

            // advance heads until they meet at the first common node
            while (h0 != h1)
            {
                h0 = h0.Next;
                h1 = h1.Next;
            }

            return h0;
        }
    }
}
