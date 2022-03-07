using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.Repositories;

namespace TTTN.TaskManagement.Services.Services
{
    public interface INotificationDetailService : IEntityService<NotificationDetail>
    {
    }

    public class NotificationDetailServices : EntityService<NotificationDetail>, INotificationDetailService
    {
        private readonly INotificationDetailRepository _notificationDetailRepository;

        public NotificationDetailServices(IUnitOfWork unitOfWork, INotificationDetailRepository repository) : base(unitOfWork, repository)
        {
            _notificationDetailRepository = repository;
        }
    }
}