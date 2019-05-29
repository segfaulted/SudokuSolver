using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Services
{
    public class BlockMemberGetter : IBlockMemberGetter
    {
        public List<SudokuCell> GetBlock(List<SudokuCell> puzzleState, int index)
        {
            var rowIndex = index / 9;
            var columnIndex = index % 9;

            var firstRowIndex = (rowIndex / 3) * 3;
            var firstColumnIndex = (columnIndex / 3) * 3;
            var firstBlockIndex = (firstRowIndex * 9) + firstColumnIndex;

            var result = new List<SudokuCell>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result.Add(puzzleState[firstBlockIndex + (i * 9) + j]);
                }
            }

            return result;
        }
    }
}
