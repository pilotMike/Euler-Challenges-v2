using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerTools.Trees;

namespace CodeEvalChallenges.Challenges
{
    public class LowestCommonAcestor : IChallenge<string>
    {
        private Node<int> _parentNode;
        private IEnumerable<string> _lines;

        public LowestCommonAcestor(IEnumerable<string> lines)
        {
            _parentNode = InitializeNodes();
            _lines = lines;
        }

        public LowestCommonAcestor(string file)
        {
            _lines = FileHelper.OpenFile(file).ToList();
            _parentNode = InitializeNodes();
        }

        private Node<int> InitializeNodes()
        {
            var n1 = new Node<int>(30);
            var n2a = new Node<int>(8);
            var n2b = new Node<int>(52);
            n1.AddChildren(new[] {n2a, n2b});
            var n3a = new Node<int>(3);
            var n3b = new Node<int>(20);
            n2a.AddChildren(new[] {n3a, n3b});
            var n4a = new Node<int>(10);
            var n4b = new Node<int>(29);
            n3b.AddChildren(new[] {n4a, n4b});

            _parentNode = n1;
            return n1;
        }

        public IEnumerable<string> Run()
        {
            return from line in _lines
                let vals = line.Split(' ').Select(int.Parse)
                let nodes = _parentNode.ChildrenContainingKey(vals)
                let lowestNode = nodes.Last(n => !vals.Except(n.Descendants().Select(d => d.Key)).Any())
                select lowestNode.Key.ToString();
        }
    }
}
