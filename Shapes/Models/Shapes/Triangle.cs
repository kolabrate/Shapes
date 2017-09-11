using System.Drawing;

namespace Shapes.Models
{
    /// <summary>
    /// The default triangle is an equilateral triangle
    /// </summary>
    public class Triangle : IShape
    {
        public Point Position { get; set; }
        public string FillColor { get; set; }
        public string StrokeColor { get; set; }
        public int StrokeWidth { get; set; }
        public int SideLength { get; set; }
    }

    public class Isoceles : Triangle
    {
        //Distance between side lengths
        public int Distance { get; set; }
    }

    //to be done later.
    public class Scalene : Triangle
    {


    }

}