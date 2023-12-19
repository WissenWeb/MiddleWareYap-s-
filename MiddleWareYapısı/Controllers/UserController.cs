using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiddleWareYapısı.Controllers
{

    public class User
    {


        public int Id { get; set; }
        public string Name { get; set; }


    }
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("AddUser")]
        public IActionResult Add(User user)
        {


            return Ok();
        }
    }
}
