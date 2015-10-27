using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class StackImplementation : IChallenge<string>
    {
        private readonly IEnumerable<MyStack<string>> _lines;

        public StackImplementation(string file) :this(FileHelper.OpenFile(file))
        {
        }

        public StackImplementation(IEnumerable<string> lines)
        {
            _lines = lines.Select(line => new MyStack<string>(line.Split(' ')));
        }

        public IEnumerable<string> Run()
        {
            return from line in _lines
                let output = EveryOtherItem(line)
                select String.Join(" ", output);
        }

        private IEnumerable<string> EveryOtherItem(MyStack<string> line)
        {
            int i = 1;
            while (line.Count > 0)
            {
                i++;
                if (i%2 == 0)
                    yield return line.Pop();
                else
                    line.Pop();
            }
        }
    }

    class MyStack<T> :IEnumerable<T>
    {
        private MyStack<T> _stack; 
        private T[] _array;
        private int _size;
        private int _version;
        private const int _defaultCapacity = 4;
        static T[] _emptyArray = new T[0];
        private T _currentElement;
        private int _index;
        
        public MyStack(IEnumerable<T> collection)
        {
            ICollection<T> c = collection as ICollection<T>;
            if (c != null)
            {
                int count = c.Count;
                _array = new T[count];
                c.CopyTo(_array, 0);
                _size = count;
            }
            else
            {
                _size = 0;
                _array = new T[_defaultCapacity];

                using (IEnumerator<T> en = collection.GetEnumerator())
                {
                    while (en.MoveNext())
                    {
                        Push(en.Current);
                    }
                }
            }
        }

        public int Count { get { return _size; } }

        public T Peek()
        {
            return _array[_size - 1];
        }

        public T Pop()
        {
            _version++;
            T item = _array[--_size];
            _array[_size] = default(T);
            return item;
        }

        public void Push(T item)
        {
            if (_size == _array.Length)
            {
                T[] newArray = new T[(_array.Length == 0) ? _defaultCapacity : 2 * _array.Length];
                Array.Copy(_array, 0, newArray, 0, _size);
                _array = newArray;
            }
            _array[_size++] = item;
            _version++;
        }


        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


}
