using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerTools.Arrays
{
    public class SpiralDiagonal
    {
        /// <summary>
        /// Calculates the sum of diagonal values in a
        /// square grid, starting with 1 in the center
        /// and incrementing clockwise.
        /// </summary>
        /// <param name="gridSize"></param>
        /// <returns></returns>
        public int CalculateSum(int gridSize)
        {
            // examle grid      49
            //21 22 23 24 25 26
            //20  7  8  9 10 27
            //19  6  1  2 11 28
            //18  5  4  3 12 29
            //17 16 15 14 13 30
         //37                31
            //                  56
            //It can be verified that the sum of the numbers on the diagonals (of the 5x5 grid) is 101.

            //method 2. Instead of creating a 2d array, calculate what the numbers would be at those positions.
            // 1 only gets counted once.
            // aggregate starting from 1, add 2 four times
            // for the next row: ending value + 3, four times
            // then + 4, four times
            // until arrray width - 1
            // sum the numbers

            int total = 1;
            int iterations = (int)Math.Ceiling((double)gridSize/2);

            var diagonals = new List<int> {1}; // seed

            for (int i = 1; i < iterations; i++)
                for (int j = 0; j < 4; j++)
                {
                    total += i*2;
                    diagonals.Add(total);
                }
           
            return diagonals.Sum();
        }
    }
}
