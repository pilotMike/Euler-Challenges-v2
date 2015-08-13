using EulerChallenges.Challenges;
using EulerTools.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EulerChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            var bench = new Benchmarker();
            var chall = new _48_SelfPowers();
            string result = "";
            bench.Benchmark(() => result = chall.Run());
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
