using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Models.Models.NotificationDetailModels
{
    public class NotificationDetailViewModel
    {
        public int NotificationDetailId { get; set; }
        public int NotificationId { get; set; }
        public int SendTo { get; set; }
        public Notification? Notification { get; set; }
        public User? User { get; set; }
        public string? UserName { get; set; }
        public string NotificationTitle { get; set; }
    }
}
