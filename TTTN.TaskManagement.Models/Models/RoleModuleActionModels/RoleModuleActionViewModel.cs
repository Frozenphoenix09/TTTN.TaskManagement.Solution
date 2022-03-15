using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Models.Models.RoleModuleActionModels
{
    public class RoleModuleActionViewModel
    {
        public int RoleModuleActionId { get; set; }
        public int RoleId { get; set; }
        public int ModuleActionId { get; set; }
        public Role? Role { get; set; }
        public string? RoleName { get; set; }
        public ModuleAction? ModuleAction { get; set; }
        public string? ModuleActionName { get; set; }
    }
}