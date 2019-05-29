using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Services.Validation
{
    public class SudokuValidator
    {
        private readonly IRowMemberGetter _rowMemberGetter;
        private readonly IColumnMemberGetter _columnMemberGetter;
        private readonly IBlockMemberGetter _blockMemberGetter;

        public SudokuValidator(IRowMemberGetter rowMemberGetter, IColumnMemberGetter columnMemberGetter, IBlockMemberGetter blockMemberGetter)
        {
            _rowMemberGetter = rowMemberGetter;
            _columnMemberGetter = columnMemberGetter;
            _blockMemberGetter = blockMemberGetter;
        }

        public bool Validate(List<SudokuCell> puzzleState, int newCellIndex, int newCellValue)
        {
            var row = _rowMemberGetter.GetRow(puzzleState, newCellIndex);
            var rowResult = row.Count(x => x.Value == newCellValue) <= 1;
            if (!rowResult)
            {
                return false;
            }
            var column = _columnMemberGetter.GetColumn(puzzleState, newCellIndex);
            var columnResult = column.Count(x => x.Value == newCellValue) <= 1;
            if (!columnResult)
            {
                return false;
            }

            var block = _blockMemberGetter.GetBlock(puzzleState, newCellIndex);

            return block.Count(x => x.Value == newCellValue) <= 1;
            ;
        }
    }
}