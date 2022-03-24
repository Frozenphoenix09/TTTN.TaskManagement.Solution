using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TTTN.TaskManagement.Data.Enums;

namespace TTTN.TaskManagement.Data.Entities
{
    public  class User : IdentityUser<int>
    {
        public string Password { get; set; }
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
    }
}
