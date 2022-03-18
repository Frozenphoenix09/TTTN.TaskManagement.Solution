using Microsoft.AspNetCore.Mvc;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Models.Models.RoleModels;
using TTTN.TaskManagement.Services.Mapper.RoleMapper;
using TTTN.TaskManagement.Services.Services;

namespace TTTN.TaskManagement.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleSerive _roleService;

        public RoleController(IRoleSerive service)
        {
            _roleService = service;
        }

        // GET: api/Role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            return await _roleService.GetAll();
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetById(int id)
        {
            var role = await _roleService.GetById(id);

            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _roleService.Update(model.MapToEntity());
                return RedirectToAction(nameof(GetAll));
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> Create(RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                await _roleService.Insert(role.MapToEntity());
                return RedirectToAction(nameof(GetAll));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                if ( await _roleService.DeleteRole(id))
                    return RedirectToAction(nameof(GetAll));
                else
                    return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}