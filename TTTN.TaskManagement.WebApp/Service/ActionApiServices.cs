using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using TTTN.TaskManagement.Data.SeedWork;
using TTTN.TaskManagement.Models.Models.ActionModels;
using TTTN.TaskManagement.Models.Models.ApiResultModels;

namespace TTTN.TaskManagement.WebApp.Service
{
    public interface IActionApiServices
    {
        public Task<PageList<ActionViewModel>> GetAll();
        public Task<PageList<ActionViewModel>> Search(ActionSearchModel model);
        public Task<ApiResultModel> Create(ActionViewModel model);
        public Task<ApiResultModel> Update(ActionViewModel model);
        public Task<ApiResultModel> Delete(int id);
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

        public async Task<ApiResultModel> Delete(int id)
        {
            var url = $"/api/Action/Delete/{id}";
            var result = await _client.DeleteAsync(url);
            return await result.Content.ReadFromJsonAsync<ApiResultModel>();
        }

        public async Task<PageList<ActionViewModel>> GetAll()
        {
            return await _client.GetFromJsonAsync <PageList<ActionViewModel>>("/api/Action/GetAll");
        }

        public async Task<ActionViewModel> GetById(int id)
        {
            var result = await _client.GetFromJsonAsync<ActionViewModel>($"/api/Action/GetById/{id}");
            return result;
        }

        public async Task<PageList<ActionViewModel>> Search(ActionSearchModel model)
        {
            var queryStringParams = new Dictionary<string, string>
            {
                ["textSearch"] = "",
                ["pageSize"] = model.PageSize.ToString(),
                ["currentPage"] = model.CurrentPage.ToString()                             
            };

            if(model.TextSearch != null)
            {
                queryStringParams["textSearch"] = model.TextSearch;
            }

            string url = QueryHelpers.AddQueryString("/api/Action/Search", queryStringParams);
            var result = await _client.GetFromJsonAsync<PageList<ActionViewModel>>(url);
            return result;
        }

        public async Task<ApiResultModel> Update(ActionViewModel model)
        {
            var result = await _client.PutAsJsonAsync("/api/Action/Update", model);
            return await result.Content.ReadFromJsonAsync<ApiResultModel>();
        }
    }
}
