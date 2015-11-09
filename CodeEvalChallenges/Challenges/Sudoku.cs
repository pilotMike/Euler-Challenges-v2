using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEvalChallenges.Challenges
{
    public class Sudoku : IChallenge<string>
    {
        private IEnumerable<SudokuGrid> _grids;

        public Sudoku()
        {
        }

        public Sudoku(IEnumerable<string> lines)
        {
            _grids = lines.Select(ParseGrid);
        }

        public SudokuGrid ParseGrid(string text)
        {
            var split = text.Split(';');
            var grid = SudokuGrid.ParseGrid(int.Parse(split[0].ToString()), split[1].Split(',').Select(int.Parse).ToArray());
            return grid;
        }

        public Sudoku(string file) : this(FileHelper.OpenFile(file))
        {
        }
        public IEnumerable<string> Run()
        {
            return from grid in _grids
                select grid.IsValid ? "True" : "False";
        }
    }

    public class SudokuGrid
    {
        private readonly int _dimensions;
        private readonly int[,] _grid;
        private readonly int _boxDimensions;

        public static SudokuGrid ParseGrid(int dimensions, int[] numbers)
        {
            // get data as array of arrays
            var rows = Enumerable.Range(0, dimensions).Select(i => numbers.Skip(i * dimensions).Take(dimensions).ToArray()).ToArray();
            // put into 2D array
            int[,] grid = new int[dimensions, dimensions];
            for (int i = 0; i < dimensions; i++)
                for (int j = 0; j < dimensions; j++)
                    grid[i, j] = rows[i][j];
            var sudokuGrid = new SudokuGrid(dimensions, grid);
            return sudokuGrid;
        }

        public SudokuGrid(int dimensions, int[,] grid)
        {
            _dimensions = dimensions;
            _grid = grid;
            _boxDimensions = (int)Math.Sqrt(dimensions);
        }

        public IEnumerable<SudokuBox> Boxes
        {
            get
            {
                return Enumerable.Range(0, _boxDimensions).Select(GetSudokuBox);
            }
        }

        public IEnumerable<IEnumerable<int>> Rows
        {
            get
            {
                return Enumerable.Range(0, _dimensions).Select(i =>
                {
                    var row = new List<int>(_dimensions);
                    for (int j = 0; j < _dimensions; j++)
                    {
                        row.Add(_grid[i, j]);
                    }
                    return row;
                });
            }
        }

        public IEnumerable<IEnumerable<int>> Columns
        {
            get
            {
                return Enumerable.Range(0, _dimensions).Select(i =>
                {
                    var row = new List<int>(_dimensions);
                    for (int j = 0; j < _dimensions; j++)
                    {
                        row.Add(_grid[j, i]);
                    }
                    return row;
                });
            }
        }

        public bool IsValid
        {
            get
            {
                var nums = Enumerable.Range(1, _dimensions).ToList();
                return Boxes.All(b => b.IsValid) && 
                    nums.All(n => 
                        Rows.All(r => r.Contains(n)) &&
                        Columns.All(c => c.Contains(n)));
            }
        }

        /// <summary>
        /// Returns the box in the grid that corresponds with its index
        /// moving from left to right, top to bottom
        /// </summary>
        private SudokuBox GetSudokuBox(int box)
        {
            int boxRow = box/_boxDimensions;
            int boxColumn = box%_boxDimensions*_boxDimensions;

            var sudokuBox = new SudokuBox(_dimensions);
            for (int x = 0; x < _boxDimensions; x++)
                for (int y = 0; y < _boxDimensions; y++)
                    sudokuBox.Numbers.Add(_grid[x+boxRow,y+boxColumn]);
                
            return sudokuBox;
        }
    }

    public class SudokuBox
    {
        /// <param name="numberRange">the upper number of numbers that are to be expected from 1 to n</param>
        public SudokuBox(int numberRange)
        {
            Numbers = new List<int>(numberRange);
            NumberRange = numberRange;
        }
        public List<int> Numbers { get; set; }

        public bool IsValid { get { return Enumerable.Range(1, NumberRange).All(n => Numbers.Contains(n)); } }
        public int NumberRange { get; set; }
    }
}
