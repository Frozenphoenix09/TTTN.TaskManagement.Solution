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
    public interface IRoleSerive : IEntityService<Role>
    {

    }
    public class RoleServices : EntityService<Role> , IRoleSerive
    {
        private readonly IRoleRepository _roleRepository;
        public RoleServices( IUnitOfWork unitOfWork , IRoleRepository repository) : base(unitOfWork,repository)
        {
            _roleRepository = repository;
        }
    }
}
