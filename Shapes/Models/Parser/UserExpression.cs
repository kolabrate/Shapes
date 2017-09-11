using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shapes.Models.Parser
{
    /// <summary>
    /// This model must be trained by capturing more user expressions. 
    /// </summary>
    public class UserExpression
    {
        public int UserExpressionId { get; set; }
        public string Expression { get; set; }
        public int IntentId { get; set; }
        public int EntityId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }

    }
}