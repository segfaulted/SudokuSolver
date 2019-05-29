using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SudokuSolver.Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Services.Test
{
    [TestFixture]
    public class SudokuValidatorTests
    {
        private MockRepository _mockRepository;
        private Fixture _fixture;
        private Mock<IRowMemberGetter> _rowMemberGetter;
        private Mock<IColumnMemberGetter> _columnMemberGetter;
        private Mock<IBlockMemberGetter> _blockMemberGetter;
        private SudokuValidator _sudokuValidator;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _mockRepository = new MockRepository(MockBehavior.Loose);
            _fixture = new Fixture();
        }

        [SetUp]
        public void Setup()
        {
            _rowMemberGetter = _mockRepository.Create<IRowMemberGetter>();
            _columnMemberGetter = _mockRepository.Create<IColumnMemberGetter>();
            _blockMemberGetter = _mockRepository.Create<IBlockMemberGetter>();

            _sudokuValidator = new SudokuValidator(_rowMemberGetter.Object, _columnMemberGetter.Object, _blockMemberGetter.Object);
        }

        [Test]
        public void Validate_WhenValid_ReturnsTrue()
        {
            _rowMemberGetter
                .Setup(x => x.GetRow(It.IsAny<List<SudokuCell>>(), It.IsAny<int>()))
                .Returns(Enumerable.Range(0, 8).Select(x => new SudokuCell { Value = x }).ToList());

            _columnMemberGetter
                .Setup(x => x.GetColumn(It.IsAny<List<SudokuCell>>(), It.IsAny<int>()))
                .Returns(Enumerable.Range(0, 8).Select(x => new SudokuCell { Value = x }).ToList());
            _blockMemberGetter
                .Setup(x => x.GetBlock(It.IsAny<List<SudokuCell>>(), It.IsAny<int>()))
                .Returns(Enumerable.Range(0, 8).Select(x => new SudokuCell { Value = x }).ToList());

            _sudokuValidator.Validate(_fixture.CreateMany<SudokuCell>().ToList(), _fixture.Create<int>(), _fixture.Create<int>()).Should().BeTrue();
        }

        [Test]
        public void Validate_WhenRowIsInvalid_ReturnsFalse()
        {
            var newCellValue = 1;
            var row = Enumerable.Range(0, 8).Select(x => new SudokuCell { Value = x }).ToList();
            row[0] = new SudokuCell { Value = newCellValue };
            row[1] = new SudokuCell { Value = newCellValue };

            _rowMemberGetter
                .Setup(x => x.GetRow(It.IsAny<List<SudokuCell>>(), It.IsAny<int>()))
                .Returns(row);

            _columnMemberGetter
                .Setup(x => x.GetColumn(It.IsAny<List<SudokuCell>>(), It.IsAny<int>()))
                .Returns(Enumerable.Range(0, 8).Select(x => new SudokuCell { Value = x }).ToList());

            _blockMemberGetter
                .Setup(x => x.GetBlock(It.IsAny<List<SudokuCell>>(), It.IsAny<int>()))
                .Returns(Enumerable.Range(0, 8).Select(x => new SudokuCell { Value = x }).ToList());

            _sudokuValidator.Validate(_fixture.CreateMany<SudokuCell>().ToList(), _fixture.Create<int>(), newCellValue).Should().BeFalse();
        }

        [Test]
        public void Validate_WhenColumnIsInvalid_ReturnsFalse()
        {
            var newCellValue = 1;
            var column = Enumerable.Range(0, 8).Select(x => new SudokuCell { Value = x }).ToList();
            column[0] = new SudokuCell { Value = newCellValue };
            column[1] = new SudokuCell { Value = newCellValue };

            _rowMemberGetter
                .Setup(x => x.GetRow(It.IsAny<List<SudokuCell>>(), It.IsAny<int>()))
                .Returns(Enumerable.Range(0, 8).Select(x => new SudokuCell { Value = x }).ToList());

            _columnMemberGetter
                .Setup(x => x.GetColumn(It.IsAny<List<SudokuCell>>(), It.IsAny<int>()))
                .Returns(column);

            _blockMemberGetter
                .Setup(x => x.GetBlock(It.IsAny<List<SudokuCell>>(), It.IsAny<int>()))
                .Returns(Enumerable.Range(0, 8).Select(x => new SudokuCell { Value = x }).ToList());

            _sudokuValidator.Validate(_fixture.CreateMany<SudokuCell>().ToList(), _fixture.Create<int>(), newCellValue).Should().BeFalse();
        }

        [Test]
        public void Validate_WhenBlockIsInvalid_ReturnsFalse()
        {
            var newCellValue = 1;
            var block = Enumerable.Range(0, 8).Select(x => new SudokuCell { Value = x }).ToList();
            block[0] = new SudokuCell { Value = newCellValue };
            block[1] = new SudokuCell { Value = newCellValue };

            _rowMemberGetter
                .Setup(x => x.GetRow(It.IsAny<List<SudokuCell>>(), It.IsAny<int>()))
                .Returns(Enumerable.Range(0, 8).Select(x => new SudokuCell { Value = x }).ToList());

            _columnMemberGetter
                .Setup(x => x.GetColumn(It.IsAny<List<SudokuCell>>(), It.IsAny<int>()))
                .Returns(Enumerable.Range(0, 8).Select(x => new SudokuCell { Value = x }).ToList());

            _blockMemberGetter
                .Setup(x => x.GetBlock(It.IsAny<List<SudokuCell>>(), It.IsAny<int>()))
                .Returns(block);

            _sudokuValidator.Validate(_fixture.CreateMany<SudokuCell>().ToList(), _fixture.Create<int>(), newCellValue).Should().BeFalse();
        }
    }
}