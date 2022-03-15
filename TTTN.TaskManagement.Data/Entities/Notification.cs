using System.ComponentModel.DataAnnotations;
using TTTN.TaskManagement.Data.Enums;

namespace TTTN.TaskManagement.Data.Entities
{
    public  class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        [Required(ErrorMessage ="Tiêu đề không được bỏ trống !")]
        [MaxLength(255)]
        public string? Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public NotificationStatus? Status { get; set; }
        public int? CreatedBy { get; set; }
        public string? Description { get; set; }
        public ICollection<NotificationDetail>? Notifications { get; set; }
    }
}
