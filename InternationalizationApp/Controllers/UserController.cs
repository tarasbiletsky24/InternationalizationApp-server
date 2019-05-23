using InternationalizationApp.DAL.Models;
using InternationalizationApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;

namespace InternationalizationApp.Controllers
{
    [AllowCrossSiteJson]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/login/{email}/{password}")]
        public HttpResponseMessage Login([FromUri]string email, [FromUri]string password)
        {
            if ((email != null) && (password != null)) return Request.CreateResponse(HttpStatusCode.OK, true);
                else return Request.CreateResponse(HttpStatusCode.OK, false);
        }

        [HttpPost]
        [Route("api/signup")]
        public HttpResponseMessage SignUp([FromBody]User value)
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpGet]
        [Route("api/check")]
        public HttpResponseMessage CheckServer()
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
