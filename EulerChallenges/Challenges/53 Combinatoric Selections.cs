using System;
using System.Linq;
using System.Numerics;

namespace Combinatorics
{
    class Program
    {
        static void Main(string[] args)
        {
           ParallelEnumerable.Range(1, 100)
                .SelectMany(n => Enumerable.Range(1, n).Select(r => new {n, r}))
                .Select(x => Comb(x.n, x.r))
                .Count(r => r > 1000000)
                .Dump();
            
            Console.ReadLine();
        }

        private static BigInteger Comb(int n, int r)
        {
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }

        private static BigInteger Factorial(int n)
        {
            return n == 0 ? 1 : n * Fact(n - 1);
        }

        private static BigInteger Fact(int n)
        {
            return Enumerable.Range(1, n).Select(x => (BigInteger)x).DefaultIfEmpty(1).Aggregate((x, total) => x * total);
        }
    }

    static class Ext
    {
        public static T Dump<T>(this T source)
        {
            Console.WriteLine(source.ToString());
            return source;
        }
    }
}
