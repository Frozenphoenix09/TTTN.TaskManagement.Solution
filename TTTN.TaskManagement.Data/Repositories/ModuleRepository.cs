using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface IModuleRepository : IBaseRepository<Module>
    {

    }
    public class ModuleRepository : BaseRepository<Module> , IModuleRepository
    {
        public ModuleRepository(TTTNTaskManagementDbcontext context) : base(context)
        {

        }
    }
}
