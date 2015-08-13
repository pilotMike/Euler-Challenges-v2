using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalChallenges
{
    public class Program
    {
        static void Main(string[] args)
        {
            var prog = new SumOfIntegers(args[0]);
            var result = prog.Run();
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
            Console.ReadLine();
        }
    }

    public class SumOfIntegers : IChallenge<int>
    {
        private IEnumerable<string> _lines;

        public SumOfIntegers(IEnumerable<string> lines)
        {
            _lines = lines;
        }

        public SumOfIntegers(string file)
        {
            _lines = FileHelper.OpenFile(file);
        }

        public IEnumerable<int> Run()
        {
            return from line in _lines
                   let numbers = line.Split(',').Select(int.Parse).ToList()
                   let greatest = GetGreatest(numbers)
                   select greatest;
        }

        private int GetGreatest(IList<int> numbers)
        {
            var dic = numbers.Select((n, i) => Tuple.Create(n, numbers.Skip(i + 1)));
            var max = 0;
            foreach (var pair in dic)
            {
                var otherNumbers = pair.Item2.Reverse();
                var sum = pair.Item1 + pair.Item2.Sum();
                var highest = sum;
                foreach (var on in otherNumbers)
                {
                    sum -= on;
                    if (highest < sum) highest = sum;
                }
                if (highest > max) max = highest;
            }
            return max;
        }
    }
    
    public class FileHelper
    {
        public static IEnumerable<string> OpenFile(string source, FileOpenOptions options = FileOpenOptions.IgnoreEmptyLines)
        {
            using (StreamReader reader = File.OpenText(source))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (options == FileOpenOptions.IgnoreEmptyLines && String.IsNullOrWhiteSpace(line))
                        continue;
                    if (line != null)
                        yield return line;
                }
            }
        }
    }

    public enum FileOpenOptions
    {
        IgnoreEmptyLines,
        AllLines
    }

    public interface IChallenge<out T>
    {
        IEnumerable<T> Run();
    }
}
