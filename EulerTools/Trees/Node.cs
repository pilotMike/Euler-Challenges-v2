using System.Collections.Generic;
using System.Linq;

namespace EulerTools.Trees
{
    public class Node<T>
    {
        private List<Node<T>> _children = new List<Node<T>>();
        public T Key { get; set; }
        public Node<T> Parent { get; set; }

        public IEnumerable<Node<T>> Children
        {
            get { return _children; }
        }

        public Node()
        {
        }

        public Node(T key, IEnumerable<Node<T>> children )
        {
            Key = key;
            _children.AddRange(children);
        }

        public Node(T key)
        {
            Key = key;
        }

        public void AddChild(Node<T> child)
        {
            child.Parent = this;
            _children.Add(child);
        }

        public void AddChildren(IEnumerable<Node<T>> children)
        {
            foreach (var child in children)
                AddChild(child);
        }
    }

    public static class NodeExtensions
    {
        public static IEnumerable<Node<T>> Descendants<T>(this Node<T> root)
        {
            var nodes = new Stack<Node<T>>(new[] { root });
            while (nodes.Any())
            {
                var node = nodes.Pop();
                yield return node;
                foreach (var n in node.Children) nodes.Push(n);
            }
        }

        public static IEnumerable<Node<T>> Parents<T>(this Node<T> node)
        {
            var nodes = new Stack<Node<T>>(new[] { node });
            while (nodes.Any())
            {
                var n = nodes.Pop();
                yield return n;
                if (n.Parent != null) nodes.Push(n.Parent);
            }
        }

        public static IEnumerable<Node<T>> ChildrenContainingKey<T>(this Node<T> source, IEnumerable<T> keys)
        {
            return source.Descendants().Where(n => keys.Any(k => n.Children.Select(c => c.Key).Any(c => c.Equals(k))));
        } 
    }
}
