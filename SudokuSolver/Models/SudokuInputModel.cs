using SudokuSolver.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class SudokuInputModel
    {
        public string SudokuInput { get; set; }
        public List<SudokuCell> Result { get; set; } = new List<SudokuCell>();
    }
}