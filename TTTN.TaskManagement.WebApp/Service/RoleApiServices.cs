using System.Net.Http.Json;
using TTTN.TaskManagement.Models.Models.RoleModels;
using TTTN.TaskManagement.Models.Models.ApiResultModels;

namespace TTTN.TaskManagement.WebApp.Service
{
    public interface IRoleApiServices
    {
        public Task<List<RoleViewModel>> GetAll();
        public Task<List<RoleViewModel>> Search(RoleSearchModel model);
        public Task<ApiResultModel> Create(RoleViewModel model);
        public Task<ApiResultModel> Update(RoleViewModel model);
        public Task<ApiResultModel> Delete(int id);
        public Task<RoleViewModel> GetById(int id);
    }
    public class RoleApiServices : IRoleApiServices
    {
        HttpClient _client;
        public RoleApiServices(HttpClient client)
        {
            _client = client;
        }
        public async Task<ApiResultModel> Create(RoleViewModel model)
        {
            var result = await _client.PostAsJsonAsync("/api/Role/Create", model);
            return await result.Content.ReadFromJsonAsync<ApiResultModel>();
        }

        public async Task<ApiResultModel> Delete(int id)
        {
            var url = $"/api/Role/Delete/{id}";
            var result = await _client.DeleteAsync(url);
            return await result.Content.ReadFromJsonAsync<ApiResultModel>();
        }

        public async Task<List<RoleViewModel>> GetAll()
        {
            return await _client.GetFromJsonAsync<List<RoleViewModel>>("/api/Role/GetAll");
        }

        public async Task<RoleViewModel> GetById(int id)
        {
            var result = await _client.GetFromJsonAsync<RoleViewModel>($"/api/Role/GetById/{id}");
            return result;
        }

        public async Task<List<RoleViewModel>> Search(RoleSearchModel model)
        {
            var url = $"/api/Role/Search?textSearch={model.TextSearch}";
            var result = await _client.GetFromJsonAsync<List<RoleViewModel>>(url);
            return result;
        }

        public async Task<ApiResultModel> Update(RoleViewModel model)
        {
            var result = await _client.PutAsJsonAsync("/api/Role/Update", model);
            return await result.Content.ReadFromJsonAsync<ApiResultModel>();
        }
    }
}
