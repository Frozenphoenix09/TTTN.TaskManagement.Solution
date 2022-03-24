using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TTTN.TaskManagement.Models.Models.ActionModels;
using TTTN.TaskManagement.WebApp.Service;

namespace TTTN.TaskManagement.WebApp.Pages.Action
{
    public partial class Edit
    {
        #region InjectServive
        [Inject]
        private IActionApiServices _actionApiServices { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Inject]
        IToastService _toastService { get; set; }
        #endregion
        #region params
        [Parameter]
        public string ActionId { get; set; }
        #endregion
        #region Variables
        private ActionViewModel action ;
        #endregion

        protected override async Task OnInitializedAsync()
        {
            action = await _actionApiServices.GetById(Convert.ToInt32(ActionId));
        }
        async void UpdateAction(EditContext context)
        {
            var respond = await _actionApiServices.Update(action);
            if (respond.StatusCode.Value)
            {
                _toastService.ShowSuccess(respond.Data["Message"].ToString(), "Success");
                _navigationManager.NavigateTo("/action");
            }
            else
            {
                _toastService.ShowSuccess(respond.Data["Message"].ToString(), "Failure");
            }
        }
    }
}
