﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeEvalChallenges
{
    public class Program
    {
        static void Main(string[] args)
        {
            var prog = new CashRegister(args[0]);
            var result = prog.Run();
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
            Console.ReadLine();
        }
    }

    public class CashRegister : IChallenge<string>
    {
        private IEnumerable<Tuple<double, double>> _lines;
        private Dictionary<int, string> _currency = new Dictionary<int, string>
        {
            {10000, "ONE HUNDRED"}, {5000,"FIFTY"}, {2000,"TWENTY"}, {1000, "TEN"}, {500,"FIVE"}, {200,"TWO"}, {100,"ONE"}, {50,"HALF DOLLAR"}, {25,"QUARTER"}, {10,"DIME"}, {05,"NICKEL"}, {01,"PENNY"}
        };

        public CashRegister(IEnumerable<string> lines)
        {
            _lines = lines.Select(line =>
            {
                var parts = line.Split(';');
                return Tuple.Create(double.Parse(parts[0]), double.Parse(parts[1]));
            });
        }

        public CashRegister(string file)
        {
            _lines = FileHelper.OpenFile(file).Select(line =>
            {
                var parts = line.Split(';');
                return Tuple.Create(double.Parse(parts[0]), double.Parse(parts[1]));
            });
        }

        public IEnumerable<string> Run()
        {
            return from pair in _lines
                   let change = GetChange(pair.Item1, pair.Item2)
                   select String.Join(",", change);
        }

        private IEnumerable<string> GetChange(double cost, double paid)
        {
            int costi = (int)(cost * Math.Pow(10, 2));
            int paidi = (int)(paid * Math.Pow(10, 2));

            if (costi > paidi) return new[] { "ERROR" };
            if (costi == paidi) return new[] { "ZERO" };
            var change = paidi - costi;
            var coins = new List<string>();
            while (change > 0)
            {
                var nextCoinPair = _currency.First(pair => change / pair.Key >= 1);
                coins.Add(nextCoinPair.Value);
                change -= nextCoinPair.Key;
            }
            return coins;
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
