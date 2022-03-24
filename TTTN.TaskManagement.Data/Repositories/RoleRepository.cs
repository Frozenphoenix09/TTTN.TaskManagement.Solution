using Microsoft.EntityFrameworkCore;
using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        public bool IsRoleExisted (string roleName);
        public List<Role> Search(string? textSearch);
        public List<Role> GetAllRole();
    }
    public  class RoleRepository : BaseRepository<Role> , IRoleRepository
    {
        public RoleRepository(TTTNTaskManagementDbcontext context) : base(context)
        {

        }

        public List<Role> GetAllRole()
        {
            var result = Dbset.AsQueryable();
            return result.Include(x => x.RoleModuleActions).ToList();
        }

        public bool IsRoleExisted(string roleName)
        {
            return Dbset.Any(x => x.RoleName == roleName);
        }

        public List<Role> Search(string? textSearch)
        {
            var result = Dbset.AsQueryable();
            if (textSearch != null)
            {
                result = result.Where(x => 
                x.RoleName.ToLower().Contains(textSearch.ToLower())|| 
                x.Description.ToLower().Contains(textSearch.ToLower()));
            }
            return result.ToList();
        }
    }
}
