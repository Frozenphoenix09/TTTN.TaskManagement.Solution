using System.Net.Http.Json;
using TTTN.TaskManagement.Models.Models.ActionModels;

namespace TTTN.TaskManagement.WebApp.Service
{
    public interface IActionApiServices
    {
        public Task<List<ActionViewModel>> GetAll();
        public Task<List<ActionViewModel>> Search(int id, string textSearch);
        public Task<ActionViewModel> Create(ActionViewModel model);
        public Task<ActionViewModel> Update(ActionViewModel model);
        public void Delete(int id);
    }
    public class ActionApiServices : IActionApiServices
    {
        HttpClient _client;
        public ActionApiServices(HttpClient client)
        {
            _client = client;
        }
        public Task<ActionViewModel> Create(ActionViewModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ActionViewModel>> GetAll()
        {
            var result = await _client.GetFromJsonAsync<List<ActionViewModel>>("/api/Action/GetAll");
            return result;
        }

        public Task<List<ActionViewModel>> Search(int id, string textSearch)
        {
            throw new NotImplementedException();
        }

        public Task<ActionViewModel> Update(ActionViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
