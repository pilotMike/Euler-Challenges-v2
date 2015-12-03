using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class ValidParentheses : IChallenge<string>
    {
        private readonly IEnumerable<string> _lines;
        private readonly Dictionary<char, char> _map = new Dictionary<char, char> {{'(',')'}, {'[',']'}, {'{','}'}}; 

        public ValidParentheses(string file) : this(FileHelper.OpenFile(file))
        {}

        public ValidParentheses(IEnumerable<string> lines )
        {
            _lines = lines;
        }

        public IEnumerable<string> Run()
        {
            return _lines.Select(line => IsValid(line) ? "True" : "False");
        }

        private bool IsValid(string line)
        {
            var stack = new Stack<char>();
            foreach (var c in line)
            {
                if (_map.Keys.Contains(c)) // open character
                    stack.Push(c);
                else // close character, check stack to see if it matches
                {
                    if (_map[stack.Peek()] == c)
                        stack.Pop();
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
