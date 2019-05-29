using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SudokuSolver.Models;
using SudokuSolver.Services;

namespace SudokuSolver.Controllers
{
    public class SudokuController : Controller
    {
        private readonly IUserInputToSudokuCellConverter _inputToSudokuCellConverter;

        public SudokuController(IUserInputToSudokuCellConverter inputToSudokuCellConverter)
        {
            _inputToSudokuCellConverter = inputToSudokuCellConverter;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult SubmitSudokuInput(SudokuInputModel input)
        {
            var inputList = input.SudokuInput
                .Split(',')
                .Select(x => Convert.ToInt32(x))
                .ToList();

            var convertedInput = _inputToSudokuCellConverter.Convert(inputList);


        }
    }
}