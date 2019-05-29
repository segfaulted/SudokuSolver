using System.Collections.Generic;

namespace SudokuSolver.Services
{
    public interface IBlockMemberGetter
    {
        List<SudokuCell> GetBlock(List<SudokuCell> puzzleState, int index);
    }
}