using System.ComponentModel.DataAnnotations;

namespace TTTN.TaskManagement.Data.Entities
{
    public  class RoleModuleAction
    {
        [Key]
        public int RoleModuleActionId { get; set; }
        public int RoleId { get; set; }
        public int ModuleActionId { get; set; }
        public Role Role { get; set; }
        public ModuleAction ModuleAction { get; set; }
    }
}
