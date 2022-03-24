using Microsoft.AspNetCore.Mvc;
using TTTN.TaskManagement.Models.Models.ActionModels;
using TTTN.TaskManagement.Models.Models.ApiResultModels;
using TTTN.TaskManagement.Services.Services;

namespace TTTN.TaskManagement.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        private readonly IActionService _ationServices;

        public ActionController(IActionService services)
        {
            _ationServices = services;
        }

        [HttpGet]
        public IActionResult GetAll(ActionSearchModel model)
        {
            var actions = _ationServices.GetAllAction(model);
            return Ok(actions);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ActionViewModel model)
        {
            var apiResult = new ApiResultModel();
            if (ModelState.IsValid)
            {
                if (_ationServices.IsActionExisted(model.ActionName))
                {
                    apiResult.StatusCode = false;
                    apiResult.Data.Add("Message", $"{model.ActionName} đã tồn tại trong hệ thống ! ");
                    return BadRequest(apiResult);
                }
                else
                {
                    if (_ationServices.CreateAction(model))
                    {
                        apiResult.StatusCode = true;
                        apiResult.Data.Add("Message", $"{model.ActionName} tạo mới thành công ! ");
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
        public IActionResult Update([FromBody] ActionViewModel model)
        {
            var apiResult = new ApiResultModel();
            if (ModelState.IsValid)
            {
                _ationServices.UpdateAction(model);
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
                if (await _ationServices.DeleteAction(id))
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
        public IActionResult Search([FromQuery] ActionSearchModel model)
        {
            var result = _ationServices.Search(model);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _ationServices.GetActionById(id);
            return Ok(result);
        }
    }
}