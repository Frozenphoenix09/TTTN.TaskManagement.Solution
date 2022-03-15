using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TTTN.TaskManagement.Data.Entities
{
    public  class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}
