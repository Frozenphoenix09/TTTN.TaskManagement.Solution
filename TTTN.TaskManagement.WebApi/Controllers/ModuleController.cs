using Microsoft.AspNetCore.Mvc;
using TTTN.TaskManagement.Models.Models.ApiResultModels;
using TTTN.TaskManagement.Models.Models.ModuleModels;
using TTTN.TaskManagement.Services.Services;

namespace TTTN.TaskManagement.WebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleServices;

        public ModuleController(IModuleService services)
        {
            _moduleServices = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var modules = _moduleServices.GetAllModule();
            return Ok(modules);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ModuleViewModel model)
        {
            var apiResult = new ApiResultModel();
            if (ModelState.IsValid)
            {
                if (_moduleServices.IsModuleExisted(model.ModuleName))
                {
                    apiResult.StatusCode = false;
                    apiResult.Data.Add("Message", $"{model.ModuleName} đã tồn tại trong hệ thống ! ");
                    return BadRequest(apiResult);
                }
                else
                {
                    if (_moduleServices.CreateModule(model))
                    {
                        apiResult.StatusCode = true;
                        apiResult.Data.Add("Message", $"{model.ModuleName} tạo mới thành công ! ");
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
        public IActionResult Update([FromBody] ModuleViewModel model)
        {
            var apiResult = new ApiResultModel();
            if (ModelState.IsValid)
            {
                _moduleServices.UpdateModule(model);
                apiResult.StatusCode = true;
                apiResult.Data.Add("Message", "Cập nhật thành công");
                return Ok(apiResult);
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
                if (await _moduleServices.DeleteModule(id))
                {
                    apiResult.StatusCode = true;
                    apiResult.Data.Add("Message", "Xóa bản ghi thành công !");
                    return Ok(apiResult);
                }
                else
                {
                    apiResult.StatusCode = false;
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
        public IActionResult Search([FromQuery] ModuleSearchModel model)
        {
            var result = _moduleServices.Search(model);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _moduleServices.GetModuleById(id);
            return Ok(result);
        }
    }
}