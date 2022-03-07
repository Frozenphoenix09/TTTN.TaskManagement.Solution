using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Models.Models.RoleModels;

namespace TTTN.TaskManagement.Services.Mapper.RoleMapper
{
    public static class RoleMapper
    {
        public static Role MapToEntity(this RoleViewModel model)
        {
            return new Role
            {
                RoleId = model.RoleId,
                RoleName = model.RoleName,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                Description = model.Description,
                UpdatedBy = model.UpdatedBy,
                UpdatedDate = model.UpdatedDate,
                RoleModuleActions = model.RoleModuleActions,
                UserRoles = model.UserRoles
            };
        }

        public static RoleViewModel MapToModel(this Role entity)
        {
            return new RoleViewModel
            {
                RoleId = entity.RoleId,
                Description = entity.Description,
                RoleModuleActions = entity.RoleModuleActions,
                CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                RoleName = entity.RoleName,
                UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy,
                UserRoles = entity.UserRoles
            };
        }

        public static List<RoleViewModel> MapToModels(this List<Role> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }

        public static List<Role> MapToEntities(this List<RoleViewModel> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }
    }
}