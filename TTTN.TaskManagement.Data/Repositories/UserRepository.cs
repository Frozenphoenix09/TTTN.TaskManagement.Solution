using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {

    }
    public class UserRepository : BaseRepository<User> , IUserRepository
    {
        public UserRepository(TTTNTaskManagementDbcontext context) : base(context)
        {

        }
    }
}
