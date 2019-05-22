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
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/login/{email}/{password}")]
        public bool Login([FromUri]string email, [FromUri]string password)
        {
            if ((email != null) && (password != null)) return true;
                else return false;
        }

        public string Get(int id)
        {
            return "value";
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
