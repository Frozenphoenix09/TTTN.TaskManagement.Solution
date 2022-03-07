using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTTN.TaskManagement.Services.Services;

namespace TTTN.TaskManagement.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;
        public UserController(IUserService userService)
        {
            _userServices = userService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var actions = _userServices.GetAll();
            return Ok();
        }
    }
}
