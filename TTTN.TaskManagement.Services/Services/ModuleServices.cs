using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.Repositories;
using TTTN.TaskManagement.Models.Models.ModuleModels;
using TTTN.TaskManagement.Services.Mapper.ModuleMapper;

namespace TTTN.TaskManagement.Services.Services
{
    public interface IModuleService : IEntityService<Module>
    {
        public bool CreateModule(ModuleViewModel model);
        public List<ModuleViewModel> GetAllModule();
        public ModuleViewModel UpdateModule(ModuleViewModel model);
        public Task<bool> DeleteModule(int id);
        public List<ModuleViewModel> Search(string? textSearch, int? id);
        public Task<ModuleViewModel> GetModuleById(int id);
    }

    public class ModuleServices : EntityService<Module>, IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleServices(IUnitOfWork unitOfWork, IModuleRepository repository) : base(unitOfWork, repository)
        {
            _moduleRepository = repository;
        }

        public bool CreateModule(ModuleViewModel model)
        {
            try
            {
                _moduleRepository.Insert(model.MapToEntity());
                UnitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteModule(int id)
        {
            try
            {
                var actionToDelete = await _moduleRepository.GetById(id);
                if (actionToDelete != null)
                {
                    _moduleRepository.Delete(actionToDelete);
                    UnitOfWork.SaveChanges();
                    return true;
                }
                else
                    return false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task< ModuleViewModel> GetModuleById(int id)
        {
            try
            {
                var resutlt =  await _moduleRepository.GetById(id);
                return resutlt.MapToModel();
            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<ModuleViewModel> GetAllModule()
        {
            var result = _moduleRepository.GetAllModule();
            return result.MapToModels();
        }

        public List<ModuleViewModel> Search(string? textSearch, int? id)
        {
            var result = _moduleRepository.Search(textSearch, id);
            if (result != null)
            {
                return result.MapToModels();
            }
            else
                return null;

        }

        public ModuleViewModel UpdateModule(ModuleViewModel model)
        {
            try
            {
                _moduleRepository.Update(model.MapToEntity());
                UnitOfWork.SaveChanges();
                return model;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}