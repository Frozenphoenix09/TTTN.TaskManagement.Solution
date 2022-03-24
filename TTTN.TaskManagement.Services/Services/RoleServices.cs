using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.Repositories;
using TTTN.TaskManagement.Models.Models.RoleModels;
using TTTN.TaskManagement.Services.Mapper.RoleMapper;

namespace TTTN.TaskManagement.Services.Services
{
    public interface IRoleSerive : IEntityService<Role>
    {
        public Task<bool> DeleteRole(int id);

        public List<RoleViewModel> GetAllRole();

        public bool CreateRole(RoleViewModel model);

        public RoleViewModel UpdateRole(RoleViewModel model);

        public List<RoleViewModel> Search(string? textSearch);

        public Task<RoleViewModel> GetRoleById(int id);

        public bool IsActionExisted(string name);
    }

    public class RoleServices : EntityService<Role>, IRoleSerive
    {
        private readonly IRoleRepository _roleRepository;

        public RoleServices(IUnitOfWork unitOfWork, IRoleRepository repository) : base(unitOfWork, repository)
        {
            _roleRepository = repository;
        }

        public bool CreateRole(RoleViewModel model)
        {
            try
            {
                _roleRepository.Insert(model.MapToEntity());
                UnitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteRole(int id)
        {
            try
            {
                var roleToDelete = await _roleRepository.GetById(id);
                if (roleToDelete != null)
                {
                    _roleRepository.Delete(roleToDelete);
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

        public List<RoleViewModel> GetAllRole()
        {
            try
            {
                return _roleRepository.GetAllRole().MapToModels();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RoleViewModel> GetRoleById(int id)
        {
            try
            {
                var result = await _roleRepository.GetById(id);
                return result.MapToModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsActionExisted(string name)
        {
            return _roleRepository.IsRoleExisted(name);
        }

        public List<RoleViewModel> Search(string? textSearch)
        {
            var result = _roleRepository.Search(textSearch);
            if (result != null)
            {
                return result.MapToModels();
            }
            else return null;
        }

        public RoleViewModel UpdateRole(RoleViewModel model)
        {
            try
            {
                _roleRepository.Update(model.MapToEntity());
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