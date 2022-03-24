using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Models.Models.NotificationDetailModels;

namespace TTTN.TaskManagement.Services.Mapper.NotificationDetailMapper
{
    public static class NotificationDetailMapper
    {
        public static NotificationDetailViewModel MapToModel (this NotificationDetail entity)
        {
            return new NotificationDetailViewModel
            {
                NotificationId = entity.NotificationId,
                NotificationDetailId = entity.NotificationDetailId,
                Notification = entity.Notification,
                NotificationTitle = entity.Notification != null ? entity.Notification.Title : "",
                UserName = entity.User != null ? entity.User.FullName : "",
                User = entity.User,
            };
        }
        public static NotificationDetail MapToEntity (this NotificationDetailViewModel model)
        {
            return new NotificationDetail
            {
                NotificationDetailId = model.NotificationId,
                NotificationId = model.NotificationId,
                Notification = model.Notification,
                User = model.User,
            };
        }
        public static List<NotificationDetail> MapToEntities(this List<NotificationDetailViewModel> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }
        public static List<NotificationDetailViewModel> MapToModels( this List<NotificationDetail> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}
