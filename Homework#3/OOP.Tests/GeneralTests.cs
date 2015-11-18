using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using OOP.Shapes;
using OOP.Shapes.Triangles;

namespace OOP.Tests
{
    [TestFixture]
    public class GeneralTests
    {
        private const double Radius = 5d;
        private const double Edge1 = 3d;
        private const double Edge2 = 4d;
        private const double Edge3 = 5d;
        private const double Hypotenuse = 5d;
        private const int CoordX = 0;
        private const int CoordY = 0;
        private const int Multiplier = 3;

        private IShape GetShape(Type shapeActualType, IDictionary<ParamKeys, object> @params)
        {
            var instance = Activator.CreateInstance(shapeActualType, @params);
            return instance as IShape;
        }

        private IDictionary<ParamKeys, object> GetParams()
        {
            return new Dictionary<ParamKeys, object>
            {
                [ParamKeys.CoordX] = CoordX,
                [ParamKeys.CoordY] = CoordY,
                [ParamKeys.Edge1] = Edge1,
                [ParamKeys.Edge2] = Edge2,
                [ParamKeys.Edge3] = Edge3,
                [ParamKeys.Radius] = Radius
            };
        }

        [Test, Sequential]
        public void AreaShouldBeCalculated([Values(
            typeof (Circle)
            , typeof (Rectangle)
            , typeof (Triangle)
            , typeof (RightTriangle)
            )] Type targetType,
            [Values(Radius*Radius*Math.PI
                , Edge1*Edge2
                , 6d
                , 6d
                )] double area)
        {
            // declare
            var @params = GetParams();
            var target = GetShape(targetType, @params);
            // act 
            var actualArea = target.GetArea();
            // assert
            actualArea.Should().Be(area);
        }

        [Test, Sequential]
        public void PerimeterShouldBeCalculated([Values(
            typeof (Circle)
            , typeof (Rectangle)
            , typeof (Triangle)
            , typeof (EquilateralTriangle)
            , typeof (RightTriangle)
            )] Type targetType,
            [Values(2*Radius*Math.PI
                , 2*(Edge1 + Edge2)
                , Edge1 + Edge2 + Edge3
                , Edge1*3
                , Edge1 + Edge2 + Hypotenuse
                )] double perimeter)
        {
            // declare
            var @params = GetParams();
            var target = GetShape(targetType, @params);
            // act 
            var actualPerimeter = target.GetPerimeter();
            // assert
            actualPerimeter.Should().Be(perimeter);
        }

        [Test, Sequential]
        public void PerimeterShouldBeCalculatedWithMultiplier([Values(
            typeof (Circle)
            , typeof (Rectangle)
            , typeof (Triangle)
            , typeof (EquilateralTriangle)
            , typeof (RightTriangle)
            )] Type targetType,
            [Values(2*Radius*Math.PI*Multiplier
                , 2*(Edge1 + Edge2)*Multiplier
                , (Edge1 + Edge2 + Edge3)*Multiplier
                , (Edge1)*3*Multiplier
                , (Edge1 + Edge2 + Hypotenuse)*Multiplier
                )] double perimeter)
        {
            // declare
            var @params = GetParams();
            var target = GetShape(targetType, @params);
            target.Multiplier = Multiplier;
            // act 
            var actualPerimeter = target.GetPerimeter();
            // assert
            actualPerimeter.Should().Be(perimeter);
        }

        [Test, Sequential]
        public void ShapeShouldBeMoved([Values(
            typeof (Circle)
            , typeof (Rectangle)
            , typeof (Triangle)
            , typeof (EquilateralTriangle)
            , typeof (RightTriangle)
            )] Type targetType)
        {
            // declare
            var @params = GetParams();
            var target = GetShape(targetType, @params);
            var coordX = (int) @params[ParamKeys.CoordX];
            var coordY = (int) @params[ParamKeys.CoordY];
            // act 
            target.Move(1, 1);
            // assert
            target.CoordX.Should().Be(coordX + 1);
            target.CoordY.Should().Be(coordY + 1);
        }

        [Test, Sequential]
        public void ShouldReturnValidShapeName([Values(
            typeof (Circle)
            , typeof (Rectangle)
            , typeof (Triangle)
            , typeof (EquilateralTriangle)
            , typeof (RightTriangle)
            )] Type targetType,
            [Values("Circle"
                , "Rectangle"
                , "Triangle"
                , "EquilateralTriangle"
                , "RightTriangle"
                )] string shapeName)
        {
            // declare
            var @params = GetParams();
            var target = GetShape(targetType, @params);
            // act 
            var actualShapeName = target.ShapeName;
            // assert
            actualShapeName.Should().Be(shapeName);
        }
    }
}