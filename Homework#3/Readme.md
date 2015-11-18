##Task #3 - OOP

###Objective:
Implement hierarchy of shapes based on interface IShape

Shapes that should be implemented: Circle, Rectangle, Triange (plus 2 special triangle cases - RightTriangle which containns 90 degrees corner and EquilateralTriangle where all edges are equal)

You are not limited with these shapes and can implement as more shapes as you wish including 3D shapes like (Cone, Piramid, Cube, Sphere etc) in this case you might require to extend interface IShape.

All shapes accept IDictionary&lt;ParamKey, object&gt; instance as parameter. This dictionary contains all possible parameteres that Shape might require.   
To succesfuly pass unit tests keep in mind following restrictions:   

**ParamKey.Radius** - means radius of circle   

**ParamKey.Edge1** - means:    
1. 1st edge of a rectangle,    
2. edge of EquilateralTriangle   
3. 1st catet of RightTriangle   
4. 1st edge of regular triangle   

**ParamKey.Edge2** - means:   
1. 2nd edge of a rectangle,   
2. 2nd catet of RightTriangle   
3. 2nd edge of regular triangle   

**ParamKey.Edge3** - means 3rd edge of a regular triangle   

**ParamKey.CoordX** and **ParamKey.CoordY** - mean CoordX and CoordY of a shape respectively   

Each shape must have constructor that receives parameter of IDictionary&lt;ParamKey, object&gt; and optionally constructor with actual values required for a shape e.g.:   
 **Circle(IDictionary&lt;ParamKey, object&gt; param)**   
 **Circle(double radius)**   
