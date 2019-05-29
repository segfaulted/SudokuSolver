using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Services.Test
{
    [TestFixture]
    public class BlockMemberGetterTests
    {
        private BlockMemberGetter _blockMemberGetter;

        public List<SudokuCell> _puzzleState { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _puzzleState = new List<SudokuCell>();
            for (int i = 0; i < 81; i++)
            {
                _puzzleState.Add(new SudokuCell { Value = i});
            }
        }

        [SetUp]
        public void Setup()
        {
            _blockMemberGetter = new BlockMemberGetter();
        }

        [Test]
        public void GetBlock_When0IsPassedIn_ReturnsListOfFirstBlock()
        {
            //arrange
            var index = 0;
            var expected = new List<int> { 0, 1, 2, 9, 10, 11, 18, 19, 20 };

            //act
            var result = _blockMemberGetter.GetBlock(_puzzleState, index);

            //assert
            result.Count.Should().Be(9);
            for (int i = 0; i < 9; i++)
            {
                result.Should().ContainEquivalentOf<SudokuCell>(new SudokuCell { Value = expected[i] });
            }
        }

        [Test]
        public void GetBlock_When23IsPassedIn_ReturnsListOfSecondBlock()
        {
            //arrange
            var index = 23;
            var expected = new List<int> { 3, 4, 5, 12, 13, 14, 21, 22, 23 };

            //act
            var result = _blockMemberGetter.GetBlock(_puzzleState, index);

            //assert
            result.Count.Should().Be(9);
            for (int i = 0; i < 9; i++)
            {
                result.Should().ContainEquivalentOf<SudokuCell>(new SudokuCell { Value = expected[i] });
            }
        }
    }
}
