using TTTN.TaskManagement.Models.Models.ActionModels;
using Action = TTTN.TaskManagement.Data.Entities.Action;

namespace TTTN.TaskManagement.Services.Mapper.ActionMapper
{
    public static class ActionMapper
    {
        public static ActionViewModel MapToModel (this Action entity)
        {
            return new ActionViewModel
            {
                ActionId = entity.ActionId,
                ActionName = entity.ActionName,
                ModuleActions = entity.ModuleActions,
            };
        }
        public static Action MapToEntity (this ActionViewModel model)
        {
            return new Action
            {
                ActionId = model.ActionId,
                ActionName = model.ActionName,
                ModuleActions = model.ModuleActions,
            };
        }
        public static List<Action> MapToEntities (this List<ActionViewModel> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }
        public static List<ActionViewModel> MapToModels(this List<Action> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}
