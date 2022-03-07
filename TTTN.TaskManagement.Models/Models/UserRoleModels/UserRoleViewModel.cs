using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Models.Models.UserRoleModels
{
    public class UserRoleViewModel
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}