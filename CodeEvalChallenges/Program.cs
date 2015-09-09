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
            var prog = new JollyJumpers(args[0]);
            var result = prog.Run();
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
            Console.ReadLine();
        }
    }

    public class JollyJumpers : IChallenge<string>
    {
        private readonly IEnumerable<Tuple<int, List<int>>> _lines;

        public JollyJumpers(string file)
        {
            _lines = FileHelper.OpenFile(file).Select(line =>
            {
                var splits = line.Split(' ').Select(int.Parse).ToArray();
                return Tuple.Create(splits[0], splits.Skip(1).ToList());
            });
        }

        public JollyJumpers(IEnumerable<string> input)
        {
            _lines = input.Select(line =>
            {
                var splits = line.Split(' ').Select(int.Parse).ToArray();
                return Tuple.Create(splits[0], splits.Skip(1).ToList());
            });
        }

        public IEnumerable<string> Run()
        {
            return from line in _lines
                   let j = IsJolly(line)
                   select j ? "Jolly" : "Not jolly";
        }

        private bool IsJolly(Tuple<int, List<int>> line)
        {
            HashSet<int> diffs = new HashSet<int>();
            line.Item2.Aggregate((acc, current) =>
            {
                diffs.Add(Math.Abs(acc - current));
                return current;
            });
            return diffs.Count(n => n > 0 && n < line.Item1) == (line.Item1 - 1);
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
