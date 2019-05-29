using System.Collections.Generic;

namespace SudokuSolver.Services
{
    public interface IColumnMemberGetter
    {
        List<SudokuCell> GetColumn(List<SudokuCell> puzzleState, int index);
    }
}