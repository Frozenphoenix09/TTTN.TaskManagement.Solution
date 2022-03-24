using System.ComponentModel.DataAnnotations;

namespace TTTN.TaskManagement.Models.Models.LoginModels
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}