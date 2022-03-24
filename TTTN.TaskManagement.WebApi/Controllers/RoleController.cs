using Microsoft.AspNetCore.Mvc;
using TTTN.TaskManagement.Models.Models.ApiResultModels;
using TTTN.TaskManagement.Models.Models.RoleModels;
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
        public IActionResult GetAll()
        {
            var roles = _roleService.GetAllRole();
            return Ok(roles);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RoleViewModel model)
        {
            var apiResult = new ApiResultModel();
            if (ModelState.IsValid)
            {
                if (_roleService.IsActionExisted(model.RoleName))
                {
                    apiResult.StatusCode = false;
                    apiResult.Data.Add("Message", $"{model.RoleName} đã tồn tại trong hệ thống ! ");
                    return BadRequest(apiResult);
                }
                else
                {
                    if (_roleService.CreateRole(model))
                    {
                        apiResult.StatusCode = true;
                        apiResult.Data.Add("Message", $"{model.RoleName} tạo mới thành công ! ");
                        return Ok(apiResult);
                    }
                    else
                    {
                        apiResult.StatusCode = false;
                        apiResult.Data.Add("Message", "Tạo mới thất bai ! Vui lòng liên hệ quản trị viên ! ");
                        return BadRequest(apiResult);
                    }
                }
            }
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Update([FromBody] RoleViewModel model)
        {
            var apiResult = new ApiResultModel();
            if (ModelState.IsValid)
            {
                _roleService.UpdateRole(model);
                apiResult.StatusCode = true;
                apiResult.Data.Add("Message", "Cập nhật thành công");
                return Ok(model);
            }
            else
            {
                apiResult.StatusCode = false;
                apiResult.Data.Add("Message", ModelState);
                return BadRequest(apiResult);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var apiResult = new ApiResultModel();
            try
            {
                if (await _roleService.DeleteRole(id))
                {
                    apiResult.StatusCode = true;
                    apiResult.Data.Add("Message", "Xóa bản ghi thành công !");
                    return Ok(apiResult);
                }
                else
                {
                    apiResult.StatusCode = true;
                    apiResult.Data.Add("Message", "Xóa bản ghi thất bại!");
                    return BadRequest(apiResult);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Search(string? textSearch)
        {
            var result = _roleService.Search(textSearch);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _roleService.GetRoleById(id);
            return Ok(result);
        }
    }
}