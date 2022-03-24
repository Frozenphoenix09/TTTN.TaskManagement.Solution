using Microsoft.AspNetCore.Components;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components.Forms;
using TTTN.TaskManagement.Models.Models.ModuleModels;
using TTTN.TaskManagement.WebApp.Service;

namespace TTTN.TaskManagement.WebApp.Pages.Module
{
    public partial class Edit
    {
        #region InjectServive
        [Inject]
        private IModuleApiServices _moduleApiServices { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Inject]
        IToastService _toastService { get; set; }
        #endregion
        #region params
        [Parameter]
        public string ModuleId { get; set; }
        #endregion
        #region Variables
        private ModuleViewModel module;
        #endregion

        protected override async Task OnInitializedAsync()
        {
            module = await _moduleApiServices.GetById(Convert.ToInt32(ModuleId));
        }
        async void UpdateModule(EditContext context)
        {
            var respond = await _moduleApiServices.Update(module);
            if (respond.StatusCode.Value)
            {
                _toastService.ShowSuccess(respond.Data["Message"].ToString(), "Success");
                _navigationManager.NavigateTo("/module");
            }
            else
            {
                _toastService.ShowSuccess(respond.Data["Message"].ToString(), "Failure");
            }
        }
    }
}
