using System.Collections.Generic;

namespace OOP.Shapes.Triangles
{
    // <summary>
    // Triangle with one 90 degrees corner
    // </summary>
    public class RightTriangle : Triangle
    {
        public RightTriangle(double edge1, double edge2, double edge3) : base(edge1, edge2, edge3)
        {
        }

        public RightTriangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
        }

        public override string ShapeName => "RightTriangle";

        protected override double Area()
        {
            return Edge1*Edge2/2;
        }
    }
}