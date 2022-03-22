using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Repositories;
using TTTN.TaskManagement.Models.Models.ActionModels;
using TTTN.TaskManagement.Services.Mapper.ActionMapper;
using Action = TTTN.TaskManagement.Data.Entities.Action;

namespace TTTN.TaskManagement.Services.Services
{
    public interface IActionService : IEntityService<Action>
    {
        public bool CreateAction(ActionViewModel model);
        public List<ActionViewModel> GetAllAction();
        public ActionViewModel UpdateAction(ActionViewModel model);
        public Task<bool> DeleteAction(int id);
        public List<ActionViewModel> Search(string? textSearch);
        public Task< ActionViewModel> GetActionById(int id);
        public bool IsActionExisted(string name);
    }
    public class ActionServices : EntityService<Action> , IActionService
    {
        private readonly IActionRepository _actionRepostiory;
        public ActionServices(IUnitOfWork unitOfWork , IActionRepository repository) :base(unitOfWork,repository)
        {
            _actionRepostiory = repository;
        }

        public bool CreateAction(ActionViewModel model)
        {
            try
            {
                _actionRepostiory.Insert(model.MapToEntity());
                UnitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAction(int id)
        {
            try
            {
                var actionToDelete = await _actionRepostiory.GetById(id);
                if(actionToDelete != null)
                {
                    _actionRepostiory.Delete(actionToDelete);
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

        public async Task<ActionViewModel> GetActionById(int id)
        {
            try
            {
                var resutlt = await _actionRepostiory.GetById(id);
                return resutlt.MapToModel();
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        public List<ActionViewModel> GetAllAction()
        {
            var result = _actionRepostiory.GetAllAction();
            return result.MapToModels();
        }

        public bool IsActionExisted(string name)
        {
            return _actionRepostiory.IsActionExisted(name);
        }

        public List<ActionViewModel> Search(string? textSearch)
        {
            var result = _actionRepostiory.Search(textSearch);
            if (result != null)
            {
                return result.MapToModels();
            }
            else return null;
        }

        public ActionViewModel UpdateAction(ActionViewModel model)
        {
            try
            {
                _actionRepostiory.Update(model.MapToEntity());
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
