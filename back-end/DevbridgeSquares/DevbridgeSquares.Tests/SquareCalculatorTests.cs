using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Logic.FindingLogic;
using DevbridgeSquares.Core.Models;
using System.Linq;

namespace DevbridgeSquares.Tests
{
    public class SquareCalculatorTests
    {
        [Test]
        public void GetSquares_Given_TwoSquaresWithSameLine_TwoSeparateSquares()
        {
            //Arrange
            var correctSquares = new List<SquareModel>
            {
                new SquareModel(
                    new PointModel() { CoordinateX = 1, CoordinateY = 1 },
                    new PointModel() { CoordinateX = 1, CoordinateY = 5 },
                    new PointModel() { CoordinateX = 5, CoordinateY = 1 },
                    new PointModel() { CoordinateX = 5, CoordinateY = 5 }
                    ),
                new SquareModel(
                    new PointModel() { CoordinateX = 5, CoordinateY = 1 },
                    new PointModel() { CoordinateX = 5, CoordinateY = 5 },
                    new PointModel() { CoordinateX = 9, CoordinateY = 1 },
                    new PointModel() { CoordinateX = 9, CoordinateY = 5 }
                    )
            };

            var points = new List<PointModel>
            {
                new PointModel(){ CoordinateX = 5, CoordinateY = 1 },
                new PointModel(){ CoordinateX = 2, CoordinateY = 2 },
                new PointModel(){ CoordinateX = 2, CoordinateY = 3 },
                new PointModel(){ CoordinateX = 3, CoordinateY = 3 },
                new PointModel(){ CoordinateX = 5, CoordinateY = 5 },
                new PointModel(){ CoordinateX = 6, CoordinateY = 7 },
                new PointModel(){ CoordinateX = 5, CoordinateY = 6 },
                new PointModel(){ CoordinateX = 1, CoordinateY = 1 },
                new PointModel(){ CoordinateX = 9, CoordinateY = 3 },
                new PointModel(){ CoordinateX = 1, CoordinateY = 5 },
                new PointModel(){ CoordinateX = 9, CoordinateY = 5 },
                new PointModel(){ CoordinateX = 9, CoordinateY = 1 }
            };
            var squareCalculator = new SquareCalculator(points);

            //Act
            var squares = squareCalculator.GetSquares();

            //Assert
            squares.Should().BeEquivalentTo(correctSquares);
        }

        [Test]
        public void GetSquares_Given_PointsWithOneSquare_OnlyOneSquare()
        {
            //Arrange
            var correctSquares = new SquareModel(
                new PointModel() { CoordinateX = 1, CoordinateY = 1 },
                new PointModel() { CoordinateX = 1, CoordinateY = 5 },
                new PointModel() { CoordinateX = 5, CoordinateY = 1 },
                new PointModel() { CoordinateX = 5, CoordinateY = 5 }
            );
            var points = new List<PointModel>
            {
                new PointModel(){ CoordinateX = 5, CoordinateY = 1 },
                new PointModel(){ CoordinateX = 2, CoordinateY = 2 },
                new PointModel(){ CoordinateX = 2, CoordinateY = 3 },
                new PointModel(){ CoordinateX = 3, CoordinateY = 3 },
                new PointModel(){ CoordinateX = 5, CoordinateY = 5 },
                new PointModel(){ CoordinateX = 6, CoordinateY = 7 },
                new PointModel(){ CoordinateX = 5, CoordinateY = 6 },
                new PointModel(){ CoordinateX = 1, CoordinateY = 1 },
                new PointModel(){ CoordinateX = 9, CoordinateY = 3 },
                new PointModel(){ CoordinateX = 1, CoordinateY = 5 }

            };
            var squareCalculator = new SquareCalculator(points);

            //Act
            var squares = squareCalculator.GetSquares();

            //Assert
            squares.Should().BeEquivalentTo(correctSquares);
        }

        [Test]
        public void RemovePointsWithoutPairs_Given_PointsWithOneSquare_OnlySquarePoints()
        {
            //Arrange
            var squarePoints = new List<PointModel>
            {
                new PointModel(){ CoordinateX = 1, CoordinateY = 1 },
                new PointModel(){ CoordinateX = 1, CoordinateY = 5 },
                new PointModel(){ CoordinateX = 5, CoordinateY = 5 },
                new PointModel(){ CoordinateX = 5, CoordinateY = 1 },
            };
            var points = new List<PointModel>
            {
                new PointModel(){ CoordinateX = 5, CoordinateY = 1 },
                new PointModel(){ CoordinateX = 2, CoordinateY = 2 },
                new PointModel(){ CoordinateX = 2, CoordinateY = 3 },
                new PointModel(){ CoordinateX = 3, CoordinateY = 3 },
                new PointModel(){ CoordinateX = 5, CoordinateY = 5 },
                new PointModel(){ CoordinateX = 6, CoordinateY = 7 },
                new PointModel(){ CoordinateX = 5, CoordinateY = 6 },
                new PointModel(){ CoordinateX = 1, CoordinateY = 1 },
                new PointModel(){ CoordinateX = 9, CoordinateY = 3 },
                new PointModel(){ CoordinateX = 1, CoordinateY = 5 }

            };
            var squareCalculator = new SquareCalculator(points);

            //Act
            squareCalculator.RemovePointsWithoutPairs();

            //Assert
            squareCalculator.Points.Should().BeEquivalentTo(squarePoints);
        }

        [Test]
        public void RemovePointsWithoutPairs_Given_RandomPointsFocusedOnOneX_emptyList()
        {
            //Arrange
            var emptyList = new List<PointModel>();
            var points = new List<PointModel>
            {
                new PointModel(){ CoordinateX = 5, CoordinateY = 8 },
                new PointModel(){ CoordinateX = 2, CoordinateY = 2 },
                new PointModel(){ CoordinateX = 2, CoordinateY = 3 },
                new PointModel(){ CoordinateX = 3, CoordinateY = 3 },
                new PointModel(){ CoordinateX = 5, CoordinateY = 5 },
                new PointModel(){ CoordinateX = 6, CoordinateY = 7 },
                new PointModel(){ CoordinateX = 5, CoordinateY = 6 },
                new PointModel(){ CoordinateX = 1, CoordinateY = 1 },
                new PointModel(){ CoordinateX = 9, CoordinateY = 3 },
                new PointModel(){ CoordinateX = 1, CoordinateY = 5 }

            };
            var squareCalculator = new SquareCalculator(points);

            //Act
            squareCalculator.RemovePointsWithoutPairs();

            //Assert
            squareCalculator.Points.Should().BeEquivalentTo(emptyList);
        }

        public void RemovePointsWithoutPairs_Given_RandomPointsFocusedOnOneY_emptyList()
        {
            //Arrange
            var emptyList = new List<PointModel>();
            var points = new List<PointModel>
            {
                new PointModel(){ CoordinateX = 2, CoordinateY = 5 },
                new PointModel(){ CoordinateX = 4, CoordinateY = 5 },
                new PointModel(){ CoordinateX = 6, CoordinateY = 5 },
                new PointModel(){ CoordinateX = 2, CoordinateY = 1 },
                new PointModel(){ CoordinateX = 4, CoordinateY = 3 },
                new PointModel(){ CoordinateX = 6, CoordinateY = 2 },
            };
            var squareCalculator = new SquareCalculator(points);

            //Act
            squareCalculator.RemovePointsWithoutPairs();

            //Assert
            squareCalculator.Points.Should().BeEquivalentTo(emptyList);
        }
    }
}
