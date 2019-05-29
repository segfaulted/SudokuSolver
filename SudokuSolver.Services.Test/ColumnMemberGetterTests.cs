using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Services.Test
{
    [TestFixture]
    public class ColumnMemberGetterTests
    {
        private ColumnMemberGetter _columnMemberGetter;

        public List<SudokuCell> _puzzleState { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _puzzleState = new List<SudokuCell>();
            for (int i = 0; i < 81; i++)
            {
                _puzzleState.Add(new SudokuCell { Value = i });
            }
        }

        [SetUp]
        public void Setup()
        {
            _columnMemberGetter = new ColumnMemberGetter();
        }

        [Test]
        public void GetColumn_When0IsPassedIn_ReturnsListOfFirstColumn()
        {
            //arrange
            var index = 1;
            var expected = new List<int> { 1, 10, 19, 28, 37, 46, 55, 64, 73 };

            //act
            var result = _columnMemberGetter.GetColumn(_puzzleState, index);

            //assert
            result.Count.Should().Be(9);
            for (var i = 0; i < 9; i++)
            {
                result.Should().ContainEquivalentOf<SudokuCell>(new SudokuCell { Value = expected[i] });
            }
        }

        [Test]
        public void GetColumn_When23IsPassedIn_ReturnsListOfFifthColumn()
        {
            //arrange
            var index = 23;
            var expected = new List<int> { 5, 14, 23, 32, 41, 50, 59, 68, 77 };

            //act
            var result = _columnMemberGetter.GetColumn(_puzzleState, index);

            //assert
            result.Count.Should().Be(9);
            for (var i = 0; i < 9; i++)
            {
                result.Should().ContainEquivalentOf<SudokuCell>(new SudokuCell { Value = expected[i] });
            }
        }
    }
}