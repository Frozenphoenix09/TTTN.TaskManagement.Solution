using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.Repositories;

namespace TTTN.TaskManagement.Services.Services
{
    public interface INotificationService : IEntityService<Notification>
    {

    }
    public class NotificationServices : EntityService<Notification> , INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        public NotificationServices(IUnitOfWork unitOfWork , INotificationRepository repository) : base(unitOfWork,repository)
        {
            _notificationRepository = repository;
        }
    }
}
