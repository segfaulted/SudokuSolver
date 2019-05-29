using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Services
{
    public class ColumnMemberGetter : IColumnMemberGetter
    {
        public List<SudokuCell> GetColumn(List<SudokuCell> puzzleState, int index)
        {
            var columnIndex = index % 9;
            var result = new List<SudokuCell>();
            for (int i = 0; i < 9; i++)
            {
                result.Add(puzzleState[columnIndex + i * 9]);
            }
            return result;
        }
    }
}