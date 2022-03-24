using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TTTN.TaskManagement.Models.Models.ActionModels;
using TTTN.TaskManagement.WebApp.Service;

namespace TTTN.TaskManagement.WebApp.Pages.Action
{
    public partial class Create
    {
        #region InjectService 
        [Inject]
        private IActionApiServices _actionApiServices { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Inject] 
        IToastService _toastService { get; set; }
        #endregion
        # region Variables
        private ActionViewModel actionViewModel = new ActionViewModel();
        #endregion

        async void CreateAction (EditContext context)
        {
            var respond = await _actionApiServices.Create(actionViewModel);
            if (respond.StatusCode.Value)
            {
                _toastService.ShowSuccess(respond.Data["Message"].ToString(), "Thành công");
                _navigationManager.NavigateTo("/action");
            }
            else
            {
                _toastService.ShowError(respond.Data["Message"].ToString(),"Lỗi");
            }
        }
    }
}
