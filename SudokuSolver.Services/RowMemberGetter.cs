using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Services
{
    public class RowMemberGetter
    {
        public List<SudokuCell> GetRow(List<SudokuCell> puzzleState, int index)
        {
            var rowIndex = index / 9;
            return puzzleState.Skip(rowIndex * 9).Take(9).ToList();
        }
    }
}