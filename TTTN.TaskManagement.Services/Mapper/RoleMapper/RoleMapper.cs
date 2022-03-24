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
                Id = model.RoleId,
                RoleName = model.RoleName,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                Description = model.Description,
                UpdatedBy = model.UpdatedBy.Value,
                UpdatedDate = model.UpdatedDate.Value,
                RoleModuleActions = model.RoleModuleActions,
            };
        }

        public static RoleViewModel MapToModel(this Role entity)
        {
            return new RoleViewModel
            {
                RoleId = entity.Id,
                Description = entity.Description,
                RoleModuleActions = entity.RoleModuleActions,
                CreatedDate = entity.CreatedDate,
                CreatedBy = entity.CreatedBy,
                RoleName = entity.RoleName,
                UpdatedDate = entity.UpdatedDate,
                UpdatedBy = entity.UpdatedBy,            
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