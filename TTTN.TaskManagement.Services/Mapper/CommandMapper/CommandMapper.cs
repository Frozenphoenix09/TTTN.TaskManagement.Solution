using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Models.Models.CommandModels;

namespace TTTN.TaskManagement.Services.Mapper.CommandMapper
{
    public static class CommandMapper
    {
        public static CommandViewModel MapToModel(this Command entity)
        {
            return new CommandViewModel
            {
                CommandId = entity.CommandId,
                CommandText = entity.CommandText,
                CreatedDate = entity.CreatedDate,
                CreatorName = entity.Creator != null ? entity.Creator.FullName : "",
                Status = entity.Status.Value,
                Creator = entity.Creator
            };
        }

        public static Command MapToEntity(this CommandViewModel model)
        {
            return new Command
            {
                CommandId = model.CommandId,
                CommandText = model.CommandText,
                CreatedDate = model.CreatedDate,
                Creator = model.Creator,
                Status = model.Status
            };
        }

        public static List<Command> MapToEntitites(this List<CommandViewModel> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }

        public static List<CommandViewModel> MapToModels(this List<Command> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}