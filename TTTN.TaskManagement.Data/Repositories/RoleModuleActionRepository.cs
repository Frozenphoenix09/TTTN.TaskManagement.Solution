using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface IRoleModuleActionRepository : IBaseRepository<RoleModuleAction>
    {

    }
    public class RoleModuleActionRepository : BaseRepository<RoleModuleAction> , IRoleModuleActionRepository
    {
        public RoleModuleActionRepository(TTTNTaskManagementDbcontext context) : base(context)
        {

        }
    }
}
