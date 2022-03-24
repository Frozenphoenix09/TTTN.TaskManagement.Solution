using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TTTN.TaskManagement.Models.Models.ModuleModels;
using TTTN.TaskManagement.WebApp.Service;
namespace TTTN.TaskManagement.WebApp.Pages.Module
{
    public partial class Create
    {
        #region InjectService 
        [Inject]
        private IModuleApiServices _moduleApiServices { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Inject]
        IToastService _toastService { get; set; }
        #endregion
        # region Variables
        private ModuleViewModel moduleViewModel = new ModuleViewModel();
        #endregion

        async void CreateModule(EditContext context)
        {
            var respond = await _moduleApiServices.Create(moduleViewModel);
            if (respond.StatusCode.Value)
            {
                _toastService.ShowSuccess(respond.Data["Message"].ToString(), "Thành công");
                _navigationManager.NavigateTo("/module");
            }
            else
            {
                _toastService.ShowError(respond.Data["Message"].ToString(), "Lỗi");
            }
        }
    }
}
