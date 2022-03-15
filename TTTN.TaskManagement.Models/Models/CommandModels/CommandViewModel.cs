using System.ComponentModel.DataAnnotations;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.Enums;

namespace TTTN.TaskManagement.Models.Models.CommandModels
{
    public class CommandViewModel
    {
        public int CommandId { get; set; }

        [Required(ErrorMessage = "Nội dung nhiệm vụ không được để trống !")]
        [MaxLength(int.MaxValue)]
        public string CommandText { get; set; }

        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public CommandStatus Status { get; set; }
        public string? CreatorName { get; set; }
        public User? Creator { get; set; }
    }
}