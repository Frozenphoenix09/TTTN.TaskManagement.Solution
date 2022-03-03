using System.ComponentModel.DataAnnotations;

namespace TTTN.TaskManagement.Data.Entities
{
    public  class Action
    {
        [Key]
        public int ActionId { get; set; }
        [Required(ErrorMessage ="Action name is required !")]
        [MaxLength(255)]
        public string ActionName { get; set; }
        public ICollection<ModuleAction> ModuleActions { get; set; }
    }
}
