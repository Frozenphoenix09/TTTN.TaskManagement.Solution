using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.Repositories;
using TTTN.TaskManagement.Models.Models.ModuleActionModels;
using TTTN.TaskManagement.Services.Mapper.ModuleActionMapper;

namespace TTTN.TaskManagement.Services.Services
{
    public interface IModuleActionService : IEntityService<ModuleAction>
    {
        public ModuleActionViewModel UpdateModuleAction(ModuleActionViewModel model);
    }

    public class ModuleActionServices : EntityService<ModuleAction>, IModuleActionService
    {
        private readonly IModuleActionRepository _moduleActionRepository;

        public ModuleActionServices(IUnitOfWork unitOfWork, IModuleActionRepository repository) : base(unitOfWork, repository)
        {
            _moduleActionRepository = repository;
        }

        public ModuleActionViewModel UpdateModuleAction(ModuleActionViewModel model)
        {
            var entity = _moduleActionRepository.GetModuleActionById(model.ModuleActionId);
            if (entity == null)
            {
                return null;
            }
            else
            {
                return _moduleActionRepository.Update(model.MapToEntity()).MapToModel();
            }
        }
    }
}