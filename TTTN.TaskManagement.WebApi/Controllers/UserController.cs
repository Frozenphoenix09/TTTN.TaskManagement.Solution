using Microsoft.AspNetCore.Mvc;
using TTTN.TaskManagement.Models.Models.UserModels;
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
        [HttpPost]
        public IActionResult Search(int? id, string? name, int? status, string? code, string textSearch)
        {
            var result = _userServices.Search(id, name, status, code, textSearch);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok("NoData");
            }
        }
        [HttpPost]
        public IActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userServices.CreateUser(model))
                {
                    return RedirectToAction(nameof(GetAll));
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}