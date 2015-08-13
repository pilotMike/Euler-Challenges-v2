using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Program
{
    public class Benchmarker
    {
        /// <summary>
        /// Performs an action while writing the time 
        /// required for completion.
        /// </summary>
        /// <param name="a"></param>
        public void Benchmark(Action a)
        {
            var sw = new Stopwatch();
            sw.Start();
            a();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
