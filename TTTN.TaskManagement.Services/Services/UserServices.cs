using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.Repositories;
using TTTN.TaskManagement.Models.Models.UserModels;
using TTTN.TaskManagement.Services.Mapper.UserMapper;

namespace TTTN.TaskManagement.Services.Services
{
    public interface IUserService : IEntityService<User>
    {
        public List<UserViewModel> Search(int? id, string? name, int? status, string? code, string? textSearch);
        public bool CreateUser(UserViewModel model);
    }

    public class UserServices : EntityService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUnitOfWork unitOfWork, IUserRepository repository) : base(unitOfWork, repository)
        {
            _userRepository = repository;
        }

        public bool CreateUser(UserViewModel model)
        {
            try
            {
                _userRepository.CreateUser(model.MapToEntity());
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<UserViewModel> Search(int? id, string? name, int? status, string? code, string? textSearch)
        {
            return _userRepository.Search(id, name, status, code, textSearch).MapToModels();
        }
    }
}