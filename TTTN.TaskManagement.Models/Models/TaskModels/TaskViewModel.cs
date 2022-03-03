using System.ComponentModel.DataAnnotations;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.Enums;
using TaskStatus= TTTN.TaskManagement.Data.Enums.TaskStatus;

namespace TTTN.TaskManagement.Models.Models.TaskModels
{
    public  class TaskViewModel
    {
        [Key]
        public int TaskId { get; set; }
        public int? AssignTo { get; set; }
        [Required(ErrorMessage = " Tên không được để trống ! ")]
        [MaxLength(255)]
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public string? AttachFile { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? TaskDeadline { get; set; }
        public TaskStatus Status { get; set; }
        public Priority Priority { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedBy { get; set; }
        public string Assignee { get; set; }
    }
}
