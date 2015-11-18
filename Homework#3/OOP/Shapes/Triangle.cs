using System;
using System.Collections.Generic;

namespace OOP.Shapes
{
    public class Triangle : ShapeBase
    {
        protected readonly double _edge1;
        protected readonly double _edge2;
        protected readonly double _edge3;

        public Triangle(double edge1, double edge2, double edge3)
            : this(new Dictionary<ParamKeys, object>
            {
                {ParamKeys.Edge1, edge1},
                {ParamKeys.Edge2, edge2},
                {ParamKeys.Edge3, edge3},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }

        public Triangle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _edge1 = (double) parameters[ParamKeys.Edge1];
            _edge2 = (double) (parameters.ContainsKey(ParamKeys.Edge2) ? parameters[ParamKeys.Edge2] : _edge1);
            _edge3 = (double) (parameters.ContainsKey(ParamKeys.Edge3) ? parameters[ParamKeys.Edge3] : _edge1);
        }

        public override string ShapeName => "Triangle";

        public double Edge1 => _edge1*(Multiplier == 0 ? 1 : Multiplier);
        public double Edge2 => _edge2*(Multiplier == 0 ? 1 : Multiplier);
        public double Edge3 => _edge3*(Multiplier == 0 ? 1 : Multiplier);

        public override double GetPerimeter()
        {
            return Edge1 + Edge2 + Edge3;
        }

        protected override double Area()
        {
            var p = GetPerimeter()/2;
            return Math.Sqrt(p*(p - Edge1)*(p - Edge2)*(p - Edge3));
        }
    }
}