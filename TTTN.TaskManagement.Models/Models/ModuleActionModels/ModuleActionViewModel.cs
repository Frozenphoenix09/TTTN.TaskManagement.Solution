using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Entities;
using Action = TTTN.TaskManagement.Data.Entities.Action;

namespace TTTN.TaskManagement.Models.Models.ModuleActionModels
{
    public class ModuleActionViewModel
    {
        public int ModuleActionId { get; set; }
        public int ModuleId { get; set; }
        public int ActionId { get; set; }
        [Required(ErrorMessage = " Tên không được bỏ trống !")]
        [MaxLength(255)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public Module? Module { get; set; }
        public string? ModuleName { get; set; }
        public Action? Action { get; set; }
        public string? ActionName { get; set; }
        public ICollection<RoleModuleAction>? RoleModuleActions { get; set; }
    }
}
