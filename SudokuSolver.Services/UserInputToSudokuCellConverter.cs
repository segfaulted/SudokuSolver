using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Services
{
    public class UserInputToSudokuCellConverter
    {
        public List<SudokuCell> Convert(List<int> input)
        {
            var result = new List<SudokuCell>();

            foreach (var item in input)
            {
                result.Add(
                    new SudokuCell
                    {
                        Value = item,
                        Fixed = item != 0
                    }
                );
            }

            return result;
        }
    }
}