using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Challenges;

namespace CodeEvalChallenges.Challenges
{
    public class ReverseWords : IChallenge<string>
    {
        private string _file;
        private IEnumerable<string> _lines; 
        public ReverseWords(string file)
        {
            _file = file;
            _lines = GetLines(file).ToList();
        }

        public ReverseWords(IEnumerable<string> text)
        {
            _lines = text;
        }

        private IEnumerable<string> GetLines(string arg)
        {
            using (StreamReader reader = File.OpenText(arg))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line != null)
                        yield return line;
                }
            }
        }

        public IEnumerable<string> Run()
        {
            var lines = _lines.Where(l => !String.IsNullOrWhiteSpace(l)).Reverse();
            return new[] {String.Join(System.Environment.NewLine, lines)};
        }
    }
}
