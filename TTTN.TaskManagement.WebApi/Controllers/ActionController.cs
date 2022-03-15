﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTTN.TaskManagement.Models.Models.ActionModels;
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
        public IActionResult GetAll()
        {
            var actions = _ationServices.GetAllAction();
            return Ok(actions);
        }
        [HttpPost]
        public IActionResult Create(ActionViewModel model)
        {
            if(ModelState.IsValid)
            {
               if(_ationServices.CreateAction(model)) 
                    return RedirectToAction(nameof(GetAll));
               else 
                    return BadRequest();
            }
            else    
                return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Update(ActionViewModel model)
        {
            if (ModelState.IsValid)
            {
                _ationServices.UpdateAction(model);
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
                if (_ationServices.DeleteAction(id))
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
        public IActionResult Search(string? textSearch , int? id)
        {
            var result = _ationServices.Search(textSearch, id);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return Ok("No Data");

        }
    }
}
