using System.Net.Http.Json;
using TTTN.TaskManagement.Models.Models.UserModels;

namespace TTTN.TaskManagement.WebApp.Service
{
    public interface IUserApiServices
    {
        public Task<List<UserViewModel>> GetAll();
        public Task<List<UserViewModel>> Search(int id, string textSearch);
        public Task<UserViewModel> Create(UserViewModel model);
        public Task<UserViewModel> Update(UserViewModel model);
        public void Delete(int id);
    }
    public class UserApiServices : IUserApiServices
    {
        HttpClient _client;
        public UserApiServices(HttpClient client)
        {
            _client = client;
        }
        public Task<UserViewModel> Create(UserViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var result = await _client.GetFromJsonAsync<List<UserViewModel>>("/api/User/GetAll");
            return result;
        }

        public Task<List<UserViewModel>> Search(int id, string textSearch)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> Update(UserViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
