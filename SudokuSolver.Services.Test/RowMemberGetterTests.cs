using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Services.Test
{
    [TestFixture]
    public class RowMemberGetterTests
    {
        private RowMemberGetter _rowMemberGetter;

        public List<SudokuCell> _puzzleState { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _puzzleState = new List<SudokuCell>();
            for (int i = 0; i < 81; i++)
            {
                _puzzleState.Add(new SudokuCell { Value = i + 1 });
            }
        }

        [SetUp]
        public void Setup()
        {
            _rowMemberGetter = new RowMemberGetter();
        }

        [Test]
        public void GetRow_When0IsPassedIn_ReturnsListWithNumbers1To9()
        {
            //arrange
            var index = 0;

            //act
            var result = _rowMemberGetter.GetRows(_puzzleState, index);

            //assert
            result.Count.Should().Be(9);
            for (var i = 1; i <= 9; i++)
            {
                result.Should().ContainEquivalentOf<SudokuCell>(new SudokuCell { Value = i });
            }
        }

        [Test]
        public void GetRow_When23IsPassedIn_ReturnsListWithNumbers19To27()
        {
            //arrange
            var index = 23;

            //act
            var result = _rowMemberGetter.GetRows(_puzzleState, index);

            //assert
            result.Count.Should().Be(9);
            for (var i = 19; i <= 27; i++)
            {
                result.Should().ContainEquivalentOf<SudokuCell>(new SudokuCell { Value = i });
            }
        }


    }
}
