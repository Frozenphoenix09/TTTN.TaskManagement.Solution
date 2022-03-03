using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface ICommandRepository : IBaseRepository<Command>
    {

    }
    public class CommandRepository : BaseRepository<Command> , ICommandRepository
    {
        public CommandRepository(TTTNTaskManagementDbcontext context) : base(context)
        {

        }
    }
}
