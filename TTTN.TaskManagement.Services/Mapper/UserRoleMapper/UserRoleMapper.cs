using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Models.Models.UserRoleModels;

namespace TTTN.TaskManagement.Services.Mapper.UserRoleMapper
{
    public static class UserRoleMapper
    {
        public static UserRoleViewModel MapToModel(this UserRole entity)
        {
            return new UserRoleViewModel
            {
                RoleId = entity.RoleId,
                RoleName = entity.Role != null ? entity.Role.RoleName : "",
                UserId = entity.UserId,
                UserRoleId = entity.RoleId,
                UserName = entity.User != null ? entity.User.FullName : "",
                User = entity.User,
                Role = entity.Role
            };
        }

        public static UserRole MapToEntity(this UserRoleViewModel model)
        {
            return new UserRole
            {
                UserRoleId = model.UserRoleId,
                UserId = model.UserId,
                RoleId = model.RoleId,
                User = model.User,
                Role = model.Role
            };
        }

        public static List<UserRoleViewModel> MapToModels(this List<UserRole> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }

        public static List<UserRole> MapToEntities(this List<UserRoleViewModel> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }
    }
}