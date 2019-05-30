using InternationalizationApp.BLL.Services;
using InternationalizationApp.DAL.Models;
using InternationalizationApp.Helper;
using InternationalizationApp.Models;
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
    public class MainController : ApiController
    {

        private readonly IUserService userService;
        private readonly IFileService fileService;
        private readonly IGitHubService gitHubService;

        public MainController(IUserService userService, IFileService fileService, IGitHubService gitHubService)
        {
            this.userService = userService;
            this.fileService = fileService;
            this.gitHubService = gitHubService;
        }

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
        public async Task<HttpResponseMessage> SignUp([FromBody]User user)
        {
            var result = await userService.AddUserAsync(user);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/check")]
        public HttpResponseMessage CheckServer()
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }

        [HttpPost]
        [Route("api/translate")]
        public async Task<HttpResponseMessage> Translate([FromBody]TranslateRequest translateRequest)
        {
            gitHubService.CloneProject(translateRequest.repositoryLink);
            var checkBranch = gitHubService.CheckBranch();

            if (!checkBranch)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Brach with name 'InternationalizationApp' does not exist");
            }

            var result = await fileService.CheckAllFiles(translateRequest.to, translateRequest.from);

            if (!result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Something went wrong please try again later.");
            }

            var changesPushed = gitHubService.PushChanges();

            if (changesPushed)
            {
                fileService.DeleteWorkingFiles();
                return Request.CreateResponse(HttpStatusCode.OK, "your project has been succesfully translated and internationalized.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Something went wrong. Could not push to GitHubRepository");
            }
        }
    }
}
