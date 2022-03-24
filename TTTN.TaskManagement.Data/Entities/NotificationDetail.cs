using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TTTN.TaskManagement.Data.Entities
{
    public class NotificationDetail
    {
        [Key]
        public int NotificationDetailId { get; set; }
        [ForeignKey("Notification")]
        public int NotificationId { get; set; }
        public Notification? Notification { get; set; }
        public User? User { get; set; }
    }
}
