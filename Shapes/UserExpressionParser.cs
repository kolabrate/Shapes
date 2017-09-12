using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Web.Services.Description;
using Shapes.Dto;

namespace Shapes
{
    public class UserExpressionParser : IDisposable
    {
        private readonly ShapeDbContext _ctx;
        private string Expression { get; set; }
        private string Intent { get; set; }
        private string Entity { get; set; }
        private List<int> _units = new List<int>();
        private IEnumerable<string> AvailableIntents { get; set; }
        private IEnumerable<string> AvailableEntities { get; set; }
        public UserExpressionParser(string userExpression)
        {
            Expression = userExpression.ToLower();
            _ctx = new ShapeDbContext();
            AvailableIntents = _ctx.Intents.Select(x => x.Synonyms).FirstOrDefault().Split('|').ToList();
            AvailableEntities = _ctx.Entities.Select(x => x.Name).FirstOrDefault().Split('|').ToList();
        }

        public IEnumerable<ValidationResult> Validate()
        {
            var results = new List<ValidationResult>();
            if (!AvailableIntents.Where(Expression.Contains).Any())
            {
                results.Add(new ValidationResult("Bummer! We do not support this intent at the moment. Please try something like 'Draw a circle'"));
            }
            if ((!AvailableEntities.Where(Expression.Contains).Any()) && (AvailableEntities.Where(Expression.Contains).Count() > 1))
            {
                results.Add(new ValidationResult("At the moment, this shape requested is not available (or) you have asked more than 1 shape to be drawn."));
            }
            string[] numbers = Regex.Split(Expression, @"\D+");
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _units.Add(int.Parse(value));
                }
            }
            if (_units == null)
                results.Add(new ValidationResult("Please specify dimensions for the shape."));
            
            return results;
        }

        public ShapeDto Response()
        {
            Intent = AvailableIntents.FirstOrDefault(Expression.Contains);
            Entity = AvailableEntities.FirstOrDefault(Expression.Contains);
            if (Intent == "draw")
            {
                switch (Entity)
                {
                    case "circle":
                            return ProcessCircle();
                    default:
                         break;
                }
            }
            return new ShapeDto() {Code = "Err_500", Html = "", Type = "", ErrorMessage = "Sorry, there is something wrong. Please try again later."};
        }

        private ShapeDto ProcessCircle()
        {
            if (_units.Count == 1)
                return new ShapeDto() {Code = "OK_200", Html = Constants.HTML_CIRCLE, Type = "Cirlce", ErrorMessage = ""};
            return new ShapeDto() { Code = "Err_400", Html = "", Type = "", ErrorMessage = "Circle must contain a single dimension. ex : Draw  me a circle with radius 100px" };
        }


        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}