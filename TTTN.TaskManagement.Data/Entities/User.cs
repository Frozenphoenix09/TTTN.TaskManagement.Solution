using System.ComponentModel.DataAnnotations;
using TTTN.TaskManagement.Data.Enums;

namespace TTTN.TaskManagement.Data.Entities
{
    public  class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Addresss { get; set; }
        public string? EmployeeCode { get; set; }
        public UserStatus Status { get; set; }
        public string? Salt { get; set; }
        public bool IsSuperAdmin { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpDatedDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? Avartar { get; set; }
        public string FullName { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
    }
}
