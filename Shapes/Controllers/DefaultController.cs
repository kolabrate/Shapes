using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Description;
using Shapes.Dto;
using Shapes.Filters;

namespace Shapes.Controllers
{
    [AllowAnonymous] //assuming security is out of scope in this exercise
    [RoutePrefix("shape")]
    public class DefaultController : ApiController
    {
        //In a real world scenario - A data layer will be required - which will implement a repo pattern.
        private ShapeDbContext _ctx;
        public DefaultController()
        {
            _ctx = new ShapeDbContext();
        }

        [Route("draw/{userExpression}")] 
        [HttpGet]
        [ResponseType(typeof(ShapeDto))]
        [ValidateExpression]
        public IHttpActionResult HtmlDraw(string userExpression)
        {
            //1)ProcessResponse();
            throw new NotImplementedException();
        }



    }
}
