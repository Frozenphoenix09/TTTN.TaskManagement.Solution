using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.Repositories;

namespace TTTN.TaskManagement.Services.Services
{
    public interface IModuleService : IEntityService<Module>
    {
    }

    public class ModuleServices : EntityService<Module>, IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleServices(IUnitOfWork unitOfWork, IModuleRepository repository) : base(unitOfWork, repository)
        {
            _moduleRepository = repository;
        }
    }
}