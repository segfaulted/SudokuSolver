using System.Collections.Generic;

namespace SudokuSolver.Services
{
    public interface IUserInputToSudokuCellConverter
    {
        List<SudokuCell> Convert(List<int> input);
    }
}