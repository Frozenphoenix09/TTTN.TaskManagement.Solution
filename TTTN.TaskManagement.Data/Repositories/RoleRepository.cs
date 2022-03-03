using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {

    }
    public  class RoleRepository : BaseRepository<Role> , IRoleRepository
    {
        public RoleRepository(TTTNTaskManagementDbcontext context) : base(context)
        {

        }
    }
}
