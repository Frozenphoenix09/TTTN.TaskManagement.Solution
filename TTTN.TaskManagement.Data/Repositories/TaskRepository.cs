using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;
using Task = TTTN.TaskManagement.Data.Entities.Task;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface ITaskRepository : IBaseRepository<Task>
    {

    }
    public  class TaskRepository : BaseRepository<Task> , ITaskRepository
    {
        public TaskRepository(TTTNTaskManagementDbcontext context) : base(context)
        {

        }
    }
}
