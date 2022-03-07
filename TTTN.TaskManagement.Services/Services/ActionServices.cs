using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Repositories;
using Action = TTTN.TaskManagement.Data.Entities.Action;

namespace TTTN.TaskManagement.Services.Services
{
    public interface IActionService : IEntityService<Action>
    {

    }
    public class ActionServices : EntityService<Action> , IActionService
    {
        private readonly IActionRepository _actionRepostiory;
        public ActionServices(IUnitOfWork unitOfWork , IActionRepository repository) :base(unitOfWork,repository)
        {
            _actionRepostiory = repository;
        }
    }
}
