using Microsoft.AspNetCore.Mvc;

namespace CwkBooking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelsController : Controller
    {
        public HotelsController()
        {
            
        }
        [HttpGet]
        public IActionResult GetRooms()
        {
            return Ok("hello");
        }
    }
}