using System.Drawing;

namespace Shapes.Models
{
    public class Square : IShape
    {
        public int Length { get; set; }

        public Point Position { get; set; }
        public string FillColor { get; set; }
        public string StrokeColor { get; set; }
        public int StrokeWidth { get; set; }
    }
}