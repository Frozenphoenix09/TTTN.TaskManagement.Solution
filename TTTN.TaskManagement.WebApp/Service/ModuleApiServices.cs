using System.Net.Http.Json;
using TTTN.TaskManagement.Models.Models.ModuleModels;
using TTTN.TaskManagement.Models.Models.ApiResultModels;
using TTTN.TaskManagement.Data.SeedWork;
using Microsoft.AspNetCore.WebUtilities;

namespace TTTN.TaskManagement.WebApp.Service
{
    public interface IModuleApiServices
    {
        public Task<PageList<ModuleViewModel>> GetAll(ModuleSearchModel model);
        public Task<PageList<ModuleViewModel>> Search(ModuleSearchModel model);
        public Task<ApiResultModel> Create(ModuleViewModel model);
        public Task<ApiResultModel> Update(ModuleViewModel model);
        public Task<ApiResultModel> Delete(int id);
        public Task<ModuleViewModel> GetById(int id);
    }
    public class ModuleApiServices : IModuleApiServices
    {
        HttpClient _client;
        public ModuleApiServices(HttpClient client)
        {
            _client = client;
        }
        public async Task<ApiResultModel> Create(ModuleViewModel model)
        {
            var result = await _client.PostAsJsonAsync("/api/Module/Create", model);
            return await result.Content.ReadFromJsonAsync<ApiResultModel>();
        }

        public async Task<ApiResultModel> Delete(int id)
        {
            var url = $"/api/Module/Delete/{id}";
            var result = await _client.DeleteAsync(url);
            return await result.Content.ReadFromJsonAsync<ApiResultModel>();
        }

        public async Task<PageList<ModuleViewModel>> GetAll(ModuleSearchModel model)
        {
            return await _client.GetFromJsonAsync<PageList<ModuleViewModel>>("/api/Module/GetAll");
        }

        public async Task<ModuleViewModel> GetById(int id)
        {
            var result = await _client.GetFromJsonAsync<ModuleViewModel>($"/api/Module/GetById/{id}");
            return result;
        }

        public async Task<PageList<ModuleViewModel>> Search(ModuleSearchModel model)
        {
            var queryStringParams = new Dictionary<string, string>
            {
                ["textSearch"] = "",
                ["pageSize"] = model.PageSize.ToString(),
                ["currentPage"] = model.CurrentPage.ToString()
            };

            if (model.TextSearch != null)
            {
                queryStringParams["textSearch"] = model.TextSearch;
            }

            string url = QueryHelpers.AddQueryString("/api/Module/Search", queryStringParams);
            var result = await _client.GetFromJsonAsync<PageList<ModuleViewModel>>(url);
            return result;
        }

        public async Task<ApiResultModel> Update(ModuleViewModel model)
        {
            var result = await _client.PutAsJsonAsync("/api/Module/Update", model);
            return await result.Content.ReadFromJsonAsync<ApiResultModel>();
        }
    }
}
