using System.Collections.Generic;

namespace SudokuSolver.Services
{
    public interface IRowMemberGetter
    {
        List<SudokuCell> GetRow(List<SudokuCell> puzzleState, int index);
    }
}