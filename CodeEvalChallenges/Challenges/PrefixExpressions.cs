using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class PrefixExpressions : IChallenge<int>
    {
        private readonly IEnumerable<Operation> _lines;
        public PrefixExpressions(string file) : this(FileHelper.OpenFile(file))
        {

        }
        public PrefixExpressions(IEnumerable<string> lines)
        {
            _lines = from line in lines
                select Operation.Parse(line);
        }
        public IEnumerable<int> Run()
        {
            return from o in _lines
                select (int)OperationRunner.Run(o);
        }
    }

    public enum Operator
    {
        Mult = '*',
        Add = '+',
        //Sub = '-',
        Div = '/',
        None
    }

    public class OperationRunner
    {
        public static double Run(Operation operation)
        {
            // it'd be nice to have F#'s seq.windowed...
            var nums = new Stack<double>(operation.Numbers.Reverse());
            var ops = new Stack<Operator>(operation.Operations);
            
            while (nums.Count > 1)
            {
                var a = nums.Pop();
                var b = nums.Pop();
                var op = ops.Pop();
                var total = Operate(a, b, op);
                nums.Push(total);
            }
            return nums.Pop();
        }

        private static double Operate(double a, double b, Operator op)
        {
            switch (op)
            {
                case Operator.Add:
                    return a + b;
                case Operator.Div:
                    return a/(double)b;
                case Operator.Mult:
                    return a*b;
                //case Operator.Sub:
                //    return a - b;
                default:
                    return 0;
            }
        }
    }

    public class Operation
    {
        private readonly IEnumerable<double> _numbers;
        private readonly IEnumerable<Operator> _operations;

        public Operation(IEnumerable<Operator> ops, IEnumerable<double> nums)
        {
            this._operations = ops;
            this._numbers = nums;
        }

        public IEnumerable<double> Numbers
        {
            get { return _numbers; }
        }

        public IEnumerable<Operator> Operations
        {
            get { return _operations; }
        }

        private static Operator GetOperator(string c)
        {
            if (c.Length != 1) return Operator.None;
            var ch = c.ToCharArray()[0];
            return (Operator) ch;
        }

        public static Operation Parse(string text)
        {
            var ops = new List<Operator>();
            List<double> nums = new List<double>();

            var split = text.Split(' ');
            foreach (var c in split)
            {
                double num;
                if (double.TryParse(c, out num))
                    nums.Add(num);
                else
                    ops.Add(GetOperator(c));
            }
            return new Operation(ops, nums);
        }
    }
}
