using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface IModuleRepository : IBaseRepository<Module>
    {
        public List<Module> GetAllModule();
        public List<Module> Search(string? textSearch, int? id);
    }
    public class ModuleRepository : BaseRepository<Module> , IModuleRepository
    {
        public ModuleRepository(TTTNTaskManagementDbcontext context) : base(context)
        {

        }

        public List<Module> GetAllModule()
        {
            return Dbset.ToList();
        }

        public List<Module> Search(string? textSearch, int? id)
        {
            var result = Dbset.AsQueryable();
            if (textSearch != null)
            {
                result = result.Where(x => x.ModuleName.ToLower().Contains(textSearch.ToLower()));
            }
            if (id != null)
            {
                result = result.Where(x => x.ModuleId == id);
            }
            if (result.Count() > 0)
            {
                return result.ToList();
            }
            else
                return null;
        }
    }
}
