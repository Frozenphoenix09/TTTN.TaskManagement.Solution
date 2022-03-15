using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Models.Models.UserModels;

namespace TTTN.TaskManagement.Services.Mapper.UserMapper
{
    public static class UserMapper
    {
        public static UserViewModel MapToModel(this User entity)
        {
            return new UserViewModel
            {
                UserId = entity.UserId,
                UserName = entity.UserName,
                Password = entity.Password,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                PlaceOfBirth = entity.PlaceOfBirth,
                DateOfBirth = entity.DateOfBirth,
                FullName = entity.FullName,
                Addresss = entity.Addresss,
                Avartar = entity.Avartar,
                Gender = entity.Gender,
                CreatedDate = entity.CreatedDate,
                EmployeeCode = entity.EmployeeCode,
                IsSuperAdmin = entity.IsSuperAdmin,
                LastLogin = entity.LastLogin,
                UpDatedDate = entity.UpDatedDate,
                Salt = entity.Salt,
                Status = entity.Status,
                UserRoles = entity.UserRoles,
            };
        }

        public static User MapToEntity(this UserViewModel model)
        {
            return new User
            {
                UserId = model.UserId,
                UserName = model.UserName,
                Password = model.Password,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                PlaceOfBirth = model.PlaceOfBirth,
                DateOfBirth = model.DateOfBirth.Value,
                FullName = model.FullName,
                Addresss = model.Addresss,
                Avartar = model.Avartar,
                Gender = model.Gender,
                CreatedDate = model.CreatedDate.Value,
                EmployeeCode = model.EmployeeCode,
                IsSuperAdmin = model.IsSuperAdmin,
                LastLogin = model.LastLogin,
                UpDatedDate = model.UpDatedDate,
                Salt = model.Salt,
                Status = model.Status.Value,
                UserRoles = model.UserRoles,
            };
        }

        public static List<UserViewModel> MapToModels(this List<User> entities)
        {
            return entities.Select(x => x.MapToModel()).ToList();
        }

        public static List<User> MapToModels(this List<UserViewModel> models)
        {
            return models.Select(x => x.MapToEntity()).ToList();
        }
    }
}