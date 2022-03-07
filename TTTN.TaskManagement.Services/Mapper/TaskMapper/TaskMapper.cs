using TTTN.TaskManagement.Models.Models.TaskModels;
using Task = TTTN.TaskManagement.Data.Entities.Task;

namespace TTTN.TaskManagement.Services.Mapper.TaskMapper
{
    public static class TaskMapper
    {
        public static TaskViewModel MapToModel(this Task entity)
        {
            return new TaskViewModel
            {
                TaskId = entity.TaskId,
                TaskDeadline = entity.TaskDeadline,
                AssignTo = entity.AssignTo,
                Status = entity.Status,
                AttachFile = entity.AttachFile,
                CreatedBy = entity.CreatedBy,
                CreatedDate = entity.CreatedDate,
                Note = entity.Note,
                Priority = entity.Priority,
                Description = entity.Description,
                TaskName = entity.TaskName,
                Assignee = entity.AssignedUser != null ? entity.AssignedUser.FullName : "",
                AssignedUser = entity.AssignedUser,
            };
        }

        public static Task MapToEntity(this TaskViewModel model)
        {
            return new Task
            {
                TaskId = model.TaskId,
                TaskDeadline = model.TaskDeadline,
                AssignTo = model.AssignTo,
                Status = model.Status,
                AttachFile = model.AttachFile,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                Note = model.Note,
                Priority = model.Priority,
                Description = model.Description,
                TaskName = model.TaskName,
                AssignedUser = model.AssignedUser,
            };
        }

        public static List<Task> MapToEntities(this List<TaskViewModel> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }

        public static List<TaskViewModel> MapToModels(this List<Task> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}