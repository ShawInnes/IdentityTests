using System.Web.Http;

namespace APIIdentityClient.Controllers
{
    [Route("status")]
    [AllowAnonymous]
    public class StatusController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Json(new
            {
                message = "OK computer"
            });
        }
    }
}