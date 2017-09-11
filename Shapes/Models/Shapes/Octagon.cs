using System.Drawing;

namespace Shapes.Models
{
    public class Octagon : IShape
    {
        public Point Position { get; set; }
        public string FillColor { get; set; }
        public string StrokeColor { get; set; }
        public int StrokeWidth { get; set; }
    }
}