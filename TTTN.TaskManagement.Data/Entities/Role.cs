using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TTTN.TaskManagement.Data.Entities
{
    public class Role : IdentityRole<int>
    {
        [Required(ErrorMessage ="Tên vai trò không được để trống !")]
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public ICollection<RoleModuleAction>? RoleModuleActions { get; set; }
    }
}
