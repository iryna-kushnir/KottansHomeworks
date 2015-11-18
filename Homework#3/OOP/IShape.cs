namespace OOP
{
    public interface IShape
    {
        /// <summary>
        ///     Returns shape actual name (e.g. circle, triangle etc)
        /// </summary>
        string ShapeName { get; }

        /// <summary>
        ///     X-coordinate of a shape
        /// </summary>
        int CoordX { get; }

        /// <summary>
        ///     Y-coordinate of a shape
        /// </summary>
        int CoordY { get; }

        /// <summary>
        ///     Multiplication factor of shape e.g. if circle radius = 5, and multiplication factor = 2, resulting radius will be
        ///     10
        /// </summary>
        byte Multiplier { get; set; }

        /// <summary>
        ///     Return shape perimeter
        /// </summary>
        /// <returns></returns>
        double GetPerimeter();

        /// <summary>
        ///     Returns shape area
        /// </summary>
        /// <returns></returns>
        double GetArea();

        /// <summary>
        ///     Change coordinates by delta value
        /// </summary>
        /// <param name="deltaX">shift value on X-axis</param>
        /// <param name="deltaY">shift value by Y-axis</param>
        void Move(int deltaX, int deltaY);
    }
}