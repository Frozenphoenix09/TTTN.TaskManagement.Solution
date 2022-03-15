using System.ComponentModel.DataAnnotations;

namespace TTTN.TaskManagement.Data.Entities
{
    public  class Module
    {
        [Key]
        public int ModuleId { get; set; }
        [Required(ErrorMessage =" Tên không được bỏ trống !")]
        [MaxLength(255)]
        public string? ModuleName { get; set; }
        public ICollection<ModuleAction>? ModuleActions { get; set; }
    }
}
