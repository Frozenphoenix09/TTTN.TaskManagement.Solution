using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.Repositories;

namespace TTTN.TaskManagement.Services.Services
{
    public interface IUserService : IEntityService<User>
    {

    }
    public class UserServices : EntityService<User> , IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUnitOfWork unitOfWork , IUserRepository repository) :base(unitOfWork,repository)
        {
            _userRepository = repository;
        }
    }
}
