using InternationalizationApp.BLL.Services;
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

        private readonly IUserService userService;

        [HttpGet]
        [Route("api/login/{login}/{password}")]
        public async Task<HttpResponseMessage> SignIn([FromUri]string login, [FromUri]string password)
        {
            var user = await userService.GetUserByLogin(login);
            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user.Password == password);
            }
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
