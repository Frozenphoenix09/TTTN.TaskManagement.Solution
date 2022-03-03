using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface INotificationDetailRepository : IBaseRepository<NotificationDetail>
    {

    }
    public class NotificationDetailRepository : BaseRepository<NotificationDetail> , INotificationDetailRepository
    {
        public NotificationDetailRepository(TTTNTaskManagementDbcontext context) : base(context)
        {

        }
    }
}
