using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Models.Models.RoleModuleActionModels;

namespace TTTN.TaskManagement.Services.Mapper.RoleModuleActionMapper
{
    public static class RoleModuleActionMapper
    {
        public static RoleModuleActionViewModel MapToModel(this RoleModuleAction entity)
        {
            return new RoleModuleActionViewModel
            {
                ModuleActionId = entity.ModuleActionId,
                ModuleAction = entity.ModuleAction,
                RoleModuleActionId = entity.RoleModuleActionId,
                Role = entity.Role,
                RoleName = entity.Role != null ? entity.Role.RoleName : "",
                ModuleActionName = entity.ModuleAction != null ? entity.ModuleAction.Name : ""
            };
        }

        public static RoleModuleAction MapToEntity(this RoleModuleActionViewModel model)
        {
            return new RoleModuleAction
            {
                ModuleActionId = model.ModuleActionId,
                RoleModuleActionId = model.RoleModuleActionId,
                ModuleAction = model.ModuleAction,
                Role = model.Role,
            };
        }

        public static List<RoleModuleAction> MapToEntities(this List<RoleModuleActionViewModel> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }

        public static List<RoleModuleActionViewModel> MapToModels(this List<RoleModuleAction> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }
    }
}