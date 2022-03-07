using System.ComponentModel.DataAnnotations;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.Enums;

namespace TTTN.TaskManagement.Models.Models.NotificationModels
{
    public class NotificationViewModel
    {
        public int NotificationId { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được bỏ trống !")]
        [MaxLength(255)]
        public string Title { get; set; }

        public DateTime CreatedDate { get; set; }
        public NotificationStatus Status { get; set; }
        public int CreatedBy { get; set; }

        [Required(ErrorMessage = "Nội dung không được để trống !")]
        public string Description { get; set; }

        public ICollection<NotificationDetail> Notifications { get; set; }
    }
}