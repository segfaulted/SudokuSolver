using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using SudokuSolver.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class UserInputSudokuCellConverterTests
    {
        private UserInputToSudokuCellConverter _UserInputSudokuCellConvert;
        private Fixture _Fixture;
        private Random _RandomGenerator;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _Fixture = new Fixture();
            _RandomGenerator = new Random();
        }

        [SetUp]
        public void Setup()
        {
            _UserInputSudokuCellConvert = new UserInputToSudokuCellConverter();
        }

        [Test]
        public void Convert_WhenUserSubmitsAllZeros_ShouldReturnListOfCellsWithFixedFalseAndValueZero()
        {
            var input = new List<int>();

            for (var i = 0; i < 81; i++)
            {
                input.Add(0);
            }

            var results = _UserInputSudokuCellConvert.Convert(input);

            results.Count.Should().Be(81);

            foreach (var cell in results)
            {
                cell.Value.Should().Be(0);
                cell.Fixed.Should().BeFalse();
            }
        }

        [Test]
        public void Convert_WhenUserSubmitsNonZeroes_ShouldReturnListOfCellsWithFixedTrueAndCorrectValues()
        {
            var input = new List<int>();

            for (var i = 0; i < 81; i++)
            {
                input.Add(_RandomGenerator.Next(1, 9));
            }

            var results = _UserInputSudokuCellConvert.Convert(input);

            results.Count.Should().Be(81);

            for(var i = 0; i < input.Count; i++)
            {
                results[i].Value.Should().Be(input[i]);
                results[i].Fixed.Should().BeTrue();
            }
        }

    }
}