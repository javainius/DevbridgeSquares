using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Core.Enums;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Logic.AddingLogic;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DevbridgeSquares.Tests
{
    public class LogicTests
    {
        [Test]
        public void ProcessPoint_Given_EmptyIntialDbList_PointAdded()
        {
            //Arrange
            int x = 1;
            int y = 2;
            var point = new PointModel(x, y);
            var dbPointList = new List<PointEntity>();
            var pointAddingLogic = new PointAddingLogic(dbPointList);

            //Act
            pointAddingLogic.ProcessPoint(point);

            //Assert
            pointAddingLogic.Point.AddingState.Should().Be(PointAddingState.Added);
        }

        [Test]
        public void ProcessPoint_Given_OutOfRangeCoordinateX_PointOutOfRange()
        {
            //Arrange
            int x = 5001;
            int y = 2;
            var point = new PointModel(x, y);
            var dbPointList = new List<PointEntity>();
            var pointAddingLogic = new PointAddingLogic(dbPointList);

            //Act
            pointAddingLogic.ProcessPoint(point);

            //Assert
            pointAddingLogic.Point.AddingState.Should().Be(PointAddingState.OutOfRange);
        }

        [Test]
        public void ProcessPoint_Given_OutOfRangeCoordinateY_PointOutOfRange()
        {
            //Arrange
            int x = 1;
            int y = 5001;
            var point = new PointModel(x, y);
            var dbPointList = new List<PointEntity>();
            var pointAddingLogic = new PointAddingLogic(dbPointList);

            //Act
            pointAddingLogic.ProcessPoint(point);

            //Assert
            pointAddingLogic.Point.AddingState.Should().Be(PointAddingState.OutOfRange);
        }

        [Test]
        public void ProcessPoint_Given_OutOfRangeCoordinates_PointOutOfRange()
        {
            //Arrange
            int x = -5001;
            int y = 5001;
            var point = new PointModel(x, y);
            var dbPointList = new List<PointEntity>();
            var pointAddingLogic = new PointAddingLogic(dbPointList);

            //Act
            pointAddingLogic.ProcessPoint(point);

            //Assert
            pointAddingLogic.Point.AddingState.Should().Be(PointAddingState.OutOfRange);
        }

        [Test]
        public void ProcessPoint_Given_DuplicatedPoint_PointDuplicated()
        {
            //Arrange
            int x = 1;
            int y = 10;
            var point = new PointModel(x, y);
            var dbPointList = new List<PointEntity>
            {
                new PointEntity(){ CoordinateX = 2, CoordinateY = 5 },
                new PointEntity(){ CoordinateX = 1, CoordinateY = 10 },
                new PointEntity(){ CoordinateX = 3, CoordinateY = 4 },
            };
            var pointAddingLogic = new PointAddingLogic(dbPointList);

            //Act
            pointAddingLogic.ProcessPoint(point);

            //Assert
            pointAddingLogic.Point.AddingState.Should().Be(PointAddingState.Duplicate);
        }

        [Test]
        public void ProcessPoint_Given_FullIntialDbList_PointOutOfSpace()
        {
            //Arrange
            int x = 1;
            int y = 10;
            var point = new PointModel(x, y);
            var dbPointList = new List<PointEntity>();
            Random rnd = new Random();
  
            for (int i = 0; i < 10000; i++)
                dbPointList.Add(new PointEntity() 
                { 
                    CoordinateX = rnd.Next(-10000, 10000), 
                    CoordinateY = rnd.Next(-10000, 10000) 
                });

            var pointAddingLogic = new PointAddingLogic(dbPointList);

            //Act
            pointAddingLogic.ProcessPoint(point);

            //Assert
            pointAddingLogic.Point.AddingState.Should().Be(PointAddingState.OutOfSpace);
        }
    }
}
