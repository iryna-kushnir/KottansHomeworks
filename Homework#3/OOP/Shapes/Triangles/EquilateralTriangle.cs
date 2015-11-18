using System;
using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    /// <summary>
    ///     triangle where all edges are equal
    /// </summary>
    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(double edge) : base(edge, edge, edge)
        {
        }

        public EquilateralTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
        }

        public override string ShapeName => "EquilateralTriangle";

        protected override double Area()
        {
            return Edge1*Edge1*Math.Sqrt(3)/4;
        }

        public override double GetPerimeter()
        {
            return Edge1*3;
        }
    }
}