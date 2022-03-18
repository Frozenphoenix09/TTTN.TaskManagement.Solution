using Microsoft.AspNetCore.Mvc;
using TTTN.TaskManagement.Models.Models.ModuleActionModels;
using TTTN.TaskManagement.Services.Mapper.ModuleActionMapper;
using TTTN.TaskManagement.Services.Services;

namespace TTTN.TaskManagement.WebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ModuleActionController : ControllerBase
    {
        private readonly IModuleActionService _moduleActionService;

        public ModuleActionController(IModuleActionService service)
        {
            _moduleActionService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var moduleActionServices = _moduleActionService.GetAll();
            return Ok(moduleActionServices);
        }

        [HttpPost]
        public IActionResult Create(ModuleActionViewModel model)
        {
            try
            {
                _moduleActionService.Insert(model.MapToEntity());
                return RedirectToAction(nameof(GetAll));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult UpDate(ModuleActionViewModel model)
        {
            try
            {
                var result = _moduleActionService.UpdateModuleAction(model);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}