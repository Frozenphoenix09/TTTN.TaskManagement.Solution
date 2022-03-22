using System.Net.Http.Json;
using TTTN.TaskManagement.Models.Models.ActionModels;
using TTTN.TaskManagement.Models.Models.ApiResultModels;

namespace TTTN.TaskManagement.WebApp.Service
{
    public interface IActionApiServices
    {
        public Task<List<ActionViewModel>> GetAll();
        public Task<List<ActionViewModel>> Search(ActionSeacrhModel model);
        public Task<ApiResultModel> Create(ActionViewModel model);
        public Task<bool> Update(ActionViewModel model);
        public Task<bool> Delete(int id);
        public Task<ActionViewModel> GetById(int id);
    }
    public class ActionApiServices : IActionApiServices
    {
        HttpClient _client;
        public ActionApiServices(HttpClient client)
        {
            _client = client;
        }
        public async Task<ApiResultModel> Create(ActionViewModel model)
        {
            var result = await _client.PostAsJsonAsync("/api/Action/Create", model);            
            return await result.Content.ReadFromJsonAsync<ApiResultModel>();           
        }

        public async Task<bool> Delete(int id)
        {
            var url = $"/api/Action/Delete/{id}";
            var result = await _client.DeleteAsync(url);
            return result.IsSuccessStatusCode;
        }

        public async Task<List<ActionViewModel>> GetAll()
        {
            return await _client.GetFromJsonAsync <List<ActionViewModel>>("/api/Action/GetAll");
        }

        public async Task<ActionViewModel> GetById(int id)
        {
            var result = await _client.GetFromJsonAsync<ActionViewModel>($"/api/Action/GetById/{id}");
            return result;
        }

        public async Task<List<ActionViewModel>> Search(ActionSeacrhModel model)
        {
            var url = $"/api/Action/Search?textSearch={model.ActionName}";
            var result = await _client.GetFromJsonAsync<List<ActionViewModel>>(url);
            return result;
        }

        public async Task<bool> Update(ActionViewModel model)
        {
            var result = await _client.PutAsJsonAsync("/api/Action/Update", model);
            return (result.IsSuccessStatusCode);
        }
    }
}
