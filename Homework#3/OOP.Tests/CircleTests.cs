using System;
using FluentAssertions;
using NUnit.Framework;
using OOP.Shapes;

namespace OOP.Tests
{
    [TestFixture]
    public class CircleTests
    {
        [Test]
        public void ShouldConvertToString()
        {
            // declare
            const double radius = 5d;

            IShape circle = new Circle(radius);
            // act 
            var info = circle.ToString();
            // assert
            info.Should().Be(
                $"Shape information: Name : {"Circle"}, X : {0}, Y : {0}, Perimeter : {2*radius*Math.PI}, Square : {radius*radius*Math.PI}");
        }

        [Test]
        public void ShouldGetInfoWithMultiplier()
        {
            // declare
            const double radius = 5d;
            const byte multiplier = 2;

            IShape circle = new Circle(radius)
            {
                Multiplier = multiplier
            };

            // act 
            var info = circle.ToString();
            // assert
            info.Should()
                .Be(
                    $"Shape information: Name : {"Circle"}, X : {0}, Y : {0}, Perimeter : {multiplier*2*radius*Math.PI}, Square : {multiplier*multiplier*radius*radius*Math.PI}");
        }
    }
}