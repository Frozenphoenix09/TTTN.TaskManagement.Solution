using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Models.Models.NotificationModels;

namespace TTTN.TaskManagement.Services.Mapper.NotificationMapper
{
    public static class NotificationMapper
    {
        public static NotificationViewModel MapToModel(this Notification entity)
        {
            return new NotificationViewModel
            {
                NotificationId = entity.NotificationId,
                CreatedBy = entity.CreatedBy,
                CreatedDate = entity.CreatedDate,
                Description = entity.Description,
                Title = entity.Title,
                Status = entity.Status,
                Notifications = entity.Notifications
            };
        }

        public static Notification MapToEntity(this NotificationViewModel model)
        {
            return new Notification
            {
                NotificationId = model.NotificationId,
                Description = model.Description,
                CreatedDate = model.CreatedDate,
                CreatedBy = model.CreatedBy,
                Status = model.Status,
                Title = model.Title,
                Notifications = model.Notifications
            };
        }

        public static List<Notification> MapToEntities(this List<NotificationViewModel> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }

        public static List<NotificationViewModel> MapToModels(this List<Notification> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}