using System.ComponentModel.DataAnnotations;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.Enums;

namespace TTTN.TaskManagement.Models.Models.UserModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Tên tài khoản không được để trống !")]
        [MaxLength(255)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống !")]
        [MaxLength(32)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Xác nhận mật khẩu không được để trống !")]
        [MaxLength(32)]
        [Compare(nameof(Password), ErrorMessage = "Xác nhận mật khẩu không trùng khớp !")]
        public string RePassword { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email không được để trống ! ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống !")]
        public string? PhoneNumber { get; set; }

        public int Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? Addresss { get; set; }
        public string? EmployeeCode { get; set; }
        public UserStatus Status { get; set; }
        public string? Salt { get; set; }
        public bool IsSuperAdmin { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpDatedDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? Avartar { get; set; }

        [Required(ErrorMessage = "Tên đầy đủ không được để trống !")]
        public string? FullName { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}