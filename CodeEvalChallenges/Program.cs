﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeEvalChallenges
{
    public class Program
    {
        static void Main(string[] args)
        {
            var prog = new OverlappingRectangles(args[0]);
            var result = prog.Run();
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
            Console.ReadLine();
        }
    }

    public class OverlappingRectangles : IChallenge<string>
    {
        private IEnumerable<Tuple<Rectangle, Rectangle>> _pairs;

        public OverlappingRectangles(string file)
            : this(FileHelper.OpenFile(file))
        { }

        public OverlappingRectangles(IEnumerable<string> lines)
        {
            _pairs = lines.Select(line =>
            {
                var parts = line.Split(',').Select(int.Parse).ToArray();
                var first = new Rectangle(parts.Take(4));
                var second = new Rectangle(parts.Skip(4));
                return Tuple.Create(first, second);
            });
        }
        public IEnumerable<string> Run()
        {
            return
                _pairs.Select(
                    pair => (pair.Item1.Contains(pair.Item2) || pair.Item2.Contains(pair.Item1)) ? "True" : "False");
        }

        class Rectangle
        {
            public Rectangle(IEnumerable<int> sections)
            {
                var en = sections.GetEnumerator();
                en.MoveNext();
                UpperLeftX = en.Current;
                en.MoveNext();
                UpperLeftY = en.Current;
                en.MoveNext();
                LowerRightX = en.Current;
                en.MoveNext();
                LowerRightY = en.Current;
            }

            int LowerRightY { get; set; }

            int LowerRightX { get; set; }

            int UpperLeftY { get; set; }

            int UpperLeftX { get; set; }

            public bool Contains(Rectangle b)
            {
                return
                    (b.UpperLeftX >= this.UpperLeftX && b.UpperLeftX <= this.LowerRightX &&
                     b.UpperLeftY <= this.UpperLeftY && b.UpperLeftY >= this.LowerRightY)
                    ||
                    (b.LowerRightX <= this.LowerRightX && b.LowerRightX >= this.UpperLeftX &&
                     b.UpperLeftY <= this.UpperLeftY && b.UpperLeftY >= this.LowerRightY)
                    ||
                    (b.UpperLeftX >= this.UpperLeftX && b.UpperLeftX <= this.LowerRightX &&
                     b.LowerRightY >= this.LowerRightY && b.LowerRightY <= this.UpperLeftY)
                    ||
                    (b.LowerRightX >= this.UpperLeftX && b.LowerRightX <= this.LowerRightX &&
                     b.LowerRightY >= this.LowerRightY && b.LowerRightY <= this.UpperLeftY)
                ;
            }
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
