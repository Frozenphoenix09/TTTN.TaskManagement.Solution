using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface IModuleActionRepository : IBaseRepository<ModuleAction>
    {
        public ModuleAction GetModuleActionById(int id);

    }
    public class ModuleActionRepository : BaseRepository<ModuleAction> , IModuleActionRepository
    {
        public ModuleActionRepository(TTTNTaskManagementDbcontext context) : base(context)
        {

        }

        public ModuleAction GetModuleActionById(int id)
        {
            var result = Dbset.AsQueryable();
            return result.Where(x => x.ModuleActionId == id).Include(x => x.Module).Include(x => x.Action).FirstOrDefault();
        }
    }
}
