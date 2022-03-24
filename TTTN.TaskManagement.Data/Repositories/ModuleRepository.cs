using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.SeedWork;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface IModuleRepository : IBaseRepository<Module>
    {
        public List<Module> GetAllModule();
        public PageList<Module> Search(string? textSearch , int currentPage, int pageSize);
        public bool IsModuleExisted(string name);
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

        public bool IsModuleExisted(string name)
        {
            return Dbset.Any(x => x.ModuleName == name);
        }

        public PageList<Module> Search(string? textSearch, int currentPage, int pageSize)
        {
            var result = Dbset.AsQueryable();

            if (textSearch != null)
            {
                result = result.Where(x => x.ModuleName.ToLower().Contains(textSearch.ToLower()));
            }

            var totalRecord = result.Count();

            var data = result.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new PageList<Module>(data, totalRecord, currentPage, pageSize);
        }
    }
}
