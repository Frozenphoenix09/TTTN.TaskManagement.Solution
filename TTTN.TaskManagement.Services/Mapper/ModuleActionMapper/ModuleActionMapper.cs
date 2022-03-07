using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Models.Models.ModuleActionModels;

namespace TTTN.TaskManagement.Services.Mapper.ModuleActionMapper
{
    public static class ModuleActionMapper
    {
        public static ModuleActionViewModel MapToModel(this ModuleAction entity)
        {
            return new ModuleActionViewModel
            {
                ModuleActionId = entity.ModuleActionId,
                Name = entity.Name,
                ModuleId = entity.ModuleActionId,
                ActionId = entity.ActionId,
                Action = entity.Action,
                Module = entity.Module,
                ActionName = entity.Action != null ? entity.Action.ActionName : "",
                ModuleName = entity.Module != null ? entity.Module.ModuleName : "",
                Description = entity.Description,
                RoleModuleActions = entity.RoleModuleActions,
            };
        }

        public static ModuleAction MapToEntity(this ModuleActionViewModel model)
        {
            return new ModuleAction
            {
                ModuleActionId = model.ModuleActionId,
                Name = model.Name,
                ActionId = model.ActionId,
                Module = model.Module,
                Description = model.Description,
                ModuleId = model.ModuleId,
                Action = model.Action,
                RoleModuleActions = model.RoleModuleActions,
            };
        }

        public static List<ModuleActionViewModel> MapToModels(this List<ModuleAction> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }

        public static List<ModuleAction> MapToEntities(this List<ModuleActionViewModel> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }
    }
}