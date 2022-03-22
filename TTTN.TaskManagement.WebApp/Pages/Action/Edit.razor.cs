using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TTTN.TaskManagement.Models.Models.ActionModels;
using TTTN.TaskManagement.WebApp.Service;

namespace TTTN.TaskManagement.WebApp.Pages.Action
{
    public partial class Edit
    {
        [Parameter]
        public string ActionId { get; set; }

        private ActionViewModel action ;

        [Inject]
        private IActionApiServices _actionApiServices { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Inject]
        IToastService _toastService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            action = await _actionApiServices.GetById(Convert.ToInt32(ActionId));
        }
        async void UpdateAction(EditContext context)
        {
            if (await _actionApiServices.Update(action))
            {
                _toastService.ShowSuccess("Cập nhật thành công !", "Success");
                _navigationManager.NavigateTo("/action");
            }
            else
            {
                _toastService.ShowSuccess("Cập nhật thất bại ! ", "Failure");
            }
        }
    }
}
