using Action = TTTN.TaskManagement.Data.Entities.Action;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface IActionRepository : IBaseRepository<Action> 
    {
    }
    public class ActionRepository :BaseRepository<Action> , IActionRepository
    {
        public ActionRepository(TTTNTaskManagementDbcontext context) : base (context)
        {

        }
    }
}
