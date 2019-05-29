using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using SudokuSolver.Services;
using System.Linq;

namespace Tests
{
    public class UserInputSudokuCellConverterTests
    {
        private UserInputToSudokuCellConverter _UserInputSudokuCellConvert;
        private Fixture _Fixture;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _Fixture = new Fixture();
        }

        [SetUp]
        public void Setup()
        {
            _UserInputSudokuCellConvert = new UserInputToSudokuCellConverter();
        }

        [Test]
        public void Convert_WhenUserSubmitsAllZeros_ShouldReturnListOfCellsWithFixedFalseAndValueZero()
        {
            var input = _Fixture.Create<Generator<int>>().Select(x => 0).Take(81).ToList();

            /*var input = new List<int>();
            for (var i = 0; i < 81; i++)
            {
                input.Add(0);
            }*/

            var results = _UserInputSudokuCellConvert.Convert(input);

            results.Count.Should().Be(81);

            foreach (var cell in results)
            {
                cell.Value.Should().Be(0);
                cell.Fixed.Should().BeFalse();
            }
        }
    }
}