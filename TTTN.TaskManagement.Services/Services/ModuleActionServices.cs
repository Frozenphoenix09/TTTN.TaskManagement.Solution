using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.Repositories;

namespace TTTN.TaskManagement.Services.Services
{
    public interface IModuleActionService : IEntityService<ModuleAction>
    {

    }
    public class ModuleActionServices : EntityService<ModuleAction> , IModuleActionService
    {
        private readonly IModuleActionRepository _moduleActionRepository;
        public ModuleActionServices(IUnitOfWork unitOfWork , IModuleActionRepository repository) : base(unitOfWork,repository)
        {
            _moduleActionRepository = repository;
        }
    }
}
