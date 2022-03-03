using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface IUserRoleRepository : IBaseRepository<UserRole>
    {

    }
    public class UserRoleRepository : BaseRepository<UserRole> , IUserRoleRepository
    {
        public UserRoleRepository(TTTNTaskManagementDbcontext context) : base(context)
        {

        }
    }
}
