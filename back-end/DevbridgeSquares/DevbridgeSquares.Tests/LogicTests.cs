using DevbridgeSquares.Core.Entities;
using DevbridgeSquares.Core.Enums;
using DevbridgeSquares.Core.Models;
using DevbridgeSquares.Logic.AddingLogic;
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
            Assert.AreEqual(PointAddingState.Added, pointAddingLogic.Point.AddingState);
        }

        [Test]
        public void ProcessPoint_Given_OutOfRangeCoordinateX_PointOutOfRange()
        {
            //Arrange
            int x = 10001;
            int y = 2;
            var point = new PointModel(x, y);
            var dbPointList = new List<PointEntity>();
            var pointAddingLogic = new PointAddingLogic(dbPointList);

            //Act
            pointAddingLogic.ProcessPoint(point);

            //Assert
            Assert.AreEqual(PointAddingState.OutOfRange, pointAddingLogic.Point.AddingState);
        }

        [Test]
        public void ProcessPoint_Given_OutOfRangeCoordinateY_PointOutOfRange()
        {
            //Arrange
            int x = 1;
            int y = 10001;
            var point = new PointModel(x, y);
            var dbPointList = new List<PointEntity>();
            var pointAddingLogic = new PointAddingLogic(dbPointList);

            //Act
            pointAddingLogic.ProcessPoint(point);

            //Assert
            Assert.AreEqual(PointAddingState.OutOfRange, pointAddingLogic.Point.AddingState);
        }

        [Test]
        public void ProcessPoint_Given_OutOfRangeCoordinates_PointOutOfRange()
        {
            //Arrange
            int x = -20001;
            int y = 10001;
            var point = new PointModel(x, y);
            var dbPointList = new List<PointEntity>();
            var pointAddingLogic = new PointAddingLogic(dbPointList);

            //Act
            pointAddingLogic.ProcessPoint(point);

            //Assert
            Assert.AreEqual(PointAddingState.OutOfRange, pointAddingLogic.Point.AddingState);
        }

        [Test]
        public void ProcessPoint_Given_DuplicatedPoint_PointOutOfRange()
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
            Assert.AreEqual(PointAddingState.Duplicate, pointAddingLogic.Point.AddingState);
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
            Assert.AreEqual(PointAddingState.OutOfSpace, pointAddingLogic.Point.AddingState);
        }
    }
}

//var points = new List<PointModel>();
//var validator = new Validator(points);
//var point = new PointModel()
//{
//    X = 1,
//    Y = 2
//};

//var output = validator.Validate(point);

//output.Successfull.Should().BeTrue();