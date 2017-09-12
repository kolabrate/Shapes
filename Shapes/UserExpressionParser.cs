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
    public class UserExpressionParser
    {
        private readonly ShapeDbContext _ctx;
        private string Expression { get; set; }
        private string Intent { get; set; }
        private string Entity { get; set; }
        private int[] Units { get; set; }
        private IEnumerable<string> AvailableIntents { get; set; }
        private IEnumerable<string> AvailableEntities { get; set; }
        public UserExpressionParser(string userExpression)
        {
            Expression = userExpression;
            _ctx = new ShapeDbContext();
            AvailableIntents = _ctx.Intents.ToList().Select(x => x.Synonyms);
            AvailableEntities = _ctx.Entities.ToList().Select(x => x.Name);
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
            int counter = 0;
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Units[counter] = int.Parse(value);
                }
              counter++;
            }
            if (Units.Length == 0)
            {
                results.Add(new ValidationResult("Please specify dimensions for the shape."));
            }
            
            return results;
        }

        public ShapeDto Response()
        {
            Intent = AvailableIntents.FirstOrDefault(Expression.Contains);
            Entity = AvailableEntities.FirstOrDefault(Expression.Contains);
            throw new NotImplementedException();

        }



    }
}