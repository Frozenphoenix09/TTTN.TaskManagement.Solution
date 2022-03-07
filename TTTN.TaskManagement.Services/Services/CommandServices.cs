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
    public interface ICommandService : IEntityService<Command>
    {

    }

    public class CommandServices : EntityService<Command> , ICommandService
    {
        private readonly ICommandRepository _commandRepository;
        public CommandServices(IUnitOfWork unitOfWork , ICommandRepository repository) : base(unitOfWork,repository)
        {
            _commandRepository = repository;
        }
    }
}
