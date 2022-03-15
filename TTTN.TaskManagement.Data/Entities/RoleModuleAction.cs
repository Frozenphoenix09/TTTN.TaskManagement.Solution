using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TTTN.TaskManagement.Data.Entities
{
    public  class RoleModuleAction
    {
        [Key]
        public int RoleModuleActionId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [ForeignKey("ModuleAction")]
        public int ModuleActionId { get; set; }
        public Role? Role { get; set; }
        public ModuleAction? ModuleAction { get; set; }
    }
}
