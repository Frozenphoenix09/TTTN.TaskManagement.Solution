using System.ComponentModel.DataAnnotations;

namespace TTTN.TaskManagement.Data.Entities
{
    public class NotificationDetail
    {
        [Key]
        public int NotificationDetailId { get; set; }
        public int NotificationId { get; set; }
        public int SendTo { get; set; }
        public Notification Notification { get; set; }
        public User User { get; set; }
    }
}
