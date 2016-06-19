using Microsoft.AspNetCore.Mvc;

namespace HeaderParseErrorRepro.Controllers
{
    [Route("services/[controller]")]
    public class AuthorizationController : Controller
    {
        [Route("")]
        public string InitScram([FromHeader(Name = "SCRAM-SHA-256")]string message)
        {
            return message ?? "<NIL>";
        }
    }
}
