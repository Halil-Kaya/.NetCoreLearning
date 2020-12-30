using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace againAndAgainWhenWillYouStop.Controllers
{

    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        public IActionResult test(){
            return Ok("islem basarili");
        }
        
    }
}