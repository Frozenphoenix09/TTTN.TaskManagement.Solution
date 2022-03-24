using Action = TTTN.TaskManagement.Data.Entities.Action;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.SeedWork;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface IActionRepository : IBaseRepository<Action> 
    {
        public PageList<Action> GetAllAction(string? textSearch, int pageSize, int currentPage);
        public PageList<Action> Search(string? textSearch , int pageSize , int currentPage);
        public bool IsActionExisted(string name);
    }
    public class ActionRepository :BaseRepository<Action> , IActionRepository
    {
        public ActionRepository(TTTNTaskManagementDbcontext context) : base (context)
        {

        }
        public PageList<Action> GetAllAction(string? textSearch, int pageSize, int currentPage)
        {
            var result =  Dbset.ToList();
            var totalRecord = result.Count();
            var data = result.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new PageList<Action>(data,totalRecord,currentPage,pageSize);
        }

        public bool IsActionExisted(string name)
        {
            return Dbset.Any(x => x.ActionName == name);
        }

        public PageList<Action> Search(string? textSearch, int pageSize, int currentPage)
        {
            var result = Dbset.AsQueryable();

            if(textSearch!= null)
            {
                result=result.Where(x=>x.ActionName.ToLower().Contains(textSearch.ToLower()));
            }

            var totalRecord = result.Count();

            var data = result.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new PageList<Action>(data, totalRecord, currentPage, pageSize);           
        }
    }
}
