using System.Drawing;

namespace Shapes.Models
{
    public class Rectangle : IShape
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Point Position { get; set; }
        public string FillColor { get; set; }
        public string StrokeColor { get; set; }
        public int StrokeWidth { get; set; }
    }
}