using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test3Controller : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Test3(Model md)
        {
            return Ok(md);
        }
    }
}
