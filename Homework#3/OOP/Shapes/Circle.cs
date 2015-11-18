using System;
using System.Collections.Generic;

namespace OOP.Shapes
{
    public class Circle : ShapeBase
    {
        private readonly double _radius;

        public Circle(double radius)
            : this(new Dictionary<ParamKeys, object>
            {
                {ParamKeys.Radius, radius},
                {ParamKeys.CoordX, 0},
                {ParamKeys.CoordY, 0}
            })
        {
        }

        public Circle(IDictionary<ParamKeys, object> parameters) : base(parameters)
        {
            _radius = (double) parameters[ParamKeys.Radius];
        }

        public double Radius => _radius*(Multiplier == 0 ? 1 : Multiplier);

        public override string ShapeName => "Circle";

        protected override double Area()
        {
            return Math.PI*Radius*Radius;
        }

        public override double GetPerimeter()
        {
            return 2*Math.PI*Radius;
        }
    }
}