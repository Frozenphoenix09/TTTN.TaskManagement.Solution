using Action = TTTN.TaskManagement.Data.Entities.Action;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface IActionRepository : IBaseRepository<Action> 
    {
        public List<Action> GetAllAction();
        public List<Action> Search(string? textSearch);
    }
    public class ActionRepository :BaseRepository<Action> , IActionRepository
    {
        public ActionRepository(TTTNTaskManagementDbcontext context) : base (context)
        {

        }
        public List<Action> GetAllAction()
        {
            return Dbset.ToList();
        }

        public List<Action> Search(string? textSearch)
        {
            var result = Dbset.AsQueryable();
            if(textSearch!= null)
            {
                result=result.Where(x=>x.ActionName.ToLower().Contains(textSearch.ToLower()));
            }            
            return result.ToList();           
        }
    }
}
