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
    public interface IUserRoleService : IEntityService<UserRole>
    {

    }
    public class UserRoleServices : EntityService<UserRole> , IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        public UserRoleServices(IUnitOfWork unitOfWork , IUserRoleRepository repository) : base(unitOfWork, repository) 
        {
            _userRoleRepository = repository;
        }
    }
}
