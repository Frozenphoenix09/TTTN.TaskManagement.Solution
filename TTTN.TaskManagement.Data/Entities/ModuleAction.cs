using System.ComponentModel.DataAnnotations;

namespace TTTN.TaskManagement.Data.Entities
{
    public class ModuleAction
    {
        [Key]
        public int ModuleActionId { get; set; }
        public int ModuleId { get; set; }
        public int ActionId { get; set; }
        [Required(ErrorMessage =" Tên không được bỏ trống !")]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }    
        public Module Module { get; set; }
        public Action Action { get; set; }
        public ICollection<RoleModuleAction> RoleModuleActions { get; set; }
    }
}
