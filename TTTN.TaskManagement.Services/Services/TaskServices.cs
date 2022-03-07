using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Repositories;
using Task = TTTN.TaskManagement.Data.Entities.Task;

namespace TTTN.TaskManagement.Services.Services
{
    public interface ITaskService : IEntityService<Task>
    {

    }
    public class TaskServices : EntityService<Task> , ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskServices(IUnitOfWork unitOfWork , ITaskRepository repository) : base(unitOfWork,repository)
        {
            _taskRepository = repository;
        }
    }
}
