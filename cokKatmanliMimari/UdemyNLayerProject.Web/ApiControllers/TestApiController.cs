using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace UdemyNLayerProject.Web.ApiControllers
{   

    [Route("api/test")]
    public class TestController : ControllerBase
    {
        

        [HttpGet]
        public IActionResult test(){

            return Ok("bu cevap testten geldi api ile mvc yi ayni anda kullandim galiba");

        }
        

        
    }
}