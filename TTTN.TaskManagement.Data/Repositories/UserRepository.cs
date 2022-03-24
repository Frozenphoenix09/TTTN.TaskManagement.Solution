using TTTN.TaskManagement.Data.Common;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Data.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public List<User> Search(int? id, string? name, int? status, string? code, string? textSearch);
        public User CreateUser(User user);
    }

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TTTNTaskManagementDbcontext context) : base(context)
        {
        }

        public User CreateUser(User user)
        {
            try
            {
                Dbset.Add(user);
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<User> Search(int? id, string? name, int? status, string? code, string? textSearch)
        {
            var result = Dbset.AsQueryable();
            if (name != null)
            {
                result = result.Where(x => x.FullName.ToLower().Contains(name.ToLower()));
            }
            if (textSearch != null)
            {
                result = result.Where(x => x.FullName.ToLower().Contains(textSearch.ToLower()) || x.Addresss.ToLower().Contains(textSearch.ToLower()) || x.EmployeeCode.ToLower().Contains(textSearch.ToLower()) || x.PhoneNumber.ToLower().Contains(textSearch.ToLower()));
            }
            if (id != null)
            {
                result = result.Where(x => x.Id == id);
            }
            if (status != null)
            {
                result = result.Where(x => (int)x.Status == status);
            }
            if (code != null)
            {
                result = result.Where(x => x.EmployeeCode == code);
            }
            if (result.Count() > 0)
            {
                return result.ToList();
            }
            else
                return null;
        }
    }
}