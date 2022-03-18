using System.Net.Http.Json;
using TTTN.TaskManagement.Models.Models.ActionModels;

namespace TTTN.TaskManagement.WebApp.Service
{
    public interface IActionApiServices
    {
        public Task<List<ActionViewModel>> GetAll();
        public Task<List<ActionViewModel>> Search(ActionSeacrhModel model);
        public Task<bool> Create(ActionViewModel model);
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
        public async Task<bool> Create(ActionViewModel model)
        {
            var result = await _client.PostAsJsonAsync("/api/Action/Create", model);
            return result.IsSuccessStatusCode;
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

        public async Task<List<ActionViewModel>> Search(ActionSeacrhModel model)
        {
            var url = $"/api/Action/Search?textSearch={model.ActionName}";
            var result = await _client.GetFromJsonAsync<List<ActionViewModel>>(url);
            return result;
        }

        public Task<ActionViewModel> Update(ActionViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
