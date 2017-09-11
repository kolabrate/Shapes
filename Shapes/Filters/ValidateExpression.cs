using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Shapes.Filters
{
    public class ValidateExpression : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext) 
        {
            throw new NotImplementedException();
        }

    }
}