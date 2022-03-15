using System.ComponentModel.DataAnnotations;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Models.Models.RoleModels
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Tên vai trò không được để trống !")]
        [MaxLength(255)]
        public string RoleName { get; set; }

        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
        public ICollection<RoleModuleAction>? RoleModuleActions { get; set; }
    }
}