using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var actions = _moduleServices.GetAllModule();
            return Ok(actions);
        }
        [HttpPost]
        public IActionResult Create(ModuleViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_moduleServices.CreateModule(model))
                    return RedirectToAction(nameof(GetAll));
                else
                    return BadRequest();
            }
            else
                return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Update(ModuleViewModel model)
        {
            if (ModelState.IsValid)
            {
                _moduleServices.UpdateModule(model);
                return Ok(model);
            }
            else
                return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_moduleServices.DeleteModule(id))
                    return RedirectToAction(nameof(GetAll));
                else
                    return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Search(string? textSearch, int? id)
        {
            var result = _moduleServices.Search(textSearch, id);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return Ok("No Data");

        }
    }
}
