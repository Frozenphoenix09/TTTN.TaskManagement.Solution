using System.ComponentModel.DataAnnotations;
using TTTN.TaskManagement.Data.Enums;

namespace TTTN.TaskManagement.Data.Entities
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public int? AssignTo { get; set; }
        [Required(ErrorMessage =" Tên không được để trống ! ")]
        [MaxLength(255)]
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public string? AttachFile { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? TaskDeadline { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public Priority Priority { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedBy { get; set; }
        public virtual User? AssignedUser { get; set; }
    }
}
