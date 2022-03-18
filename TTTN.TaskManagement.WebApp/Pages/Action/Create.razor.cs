using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TTTN.TaskManagement.Models.Models.ActionModels;
using TTTN.TaskManagement.WebApp.Service;

namespace TTTN.TaskManagement.WebApp.Pages.Action
{
    public partial class Create
    {
        [Inject]
        private IActionApiServices _actionApiServices { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Inject] 
        IToastService _toastService { get; set; }

        private ActionViewModel actionViewModel = new ActionViewModel();

        async void CreateAction (EditContext context)
        {
            if ( await _actionApiServices.Create(actionViewModel))
            {
                _toastService.ShowSuccess("Tạo mới thành công !", "Success");
                _navigationManager.NavigateTo("/action");
            }
            else
            {
                _toastService.ShowSuccess("Tạo mới thất bại ! ", "Failure");
            }
        }
    }
}
