using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {

    }
    public  class NotificationRepository : BaseRepository<Notification> , INotificationRepository
    {
        public NotificationRepository(TTTNTaskManagementDbcontext context) : base(context)
        {

        }
    }
}
