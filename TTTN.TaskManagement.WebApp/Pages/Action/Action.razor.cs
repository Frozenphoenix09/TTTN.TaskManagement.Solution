using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TTTN.TaskManagement.Models.Models.ActionModels;
using TTTN.TaskManagement.WebApp.Components;
using TTTN.TaskManagement.WebApp.Service;

namespace TTTN.TaskManagement.WebApp.Pages.Action
{
    public partial class Action
    {
        #region InjectServices
        [Inject] 
        private IActionApiServices _actionApiServices { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Inject]
        IToastService _toastService { get; set; }
        #endregion
        #region Properties
        protected Confirmation DeleteConfirmation { get; set; }

        private int DeleteId { get; set; }
        private string   ActionName { get; set; }
        #endregion
        #region Variables
        private List<ActionViewModel> actions;
        private ActionSeacrhModel searchModel = new ActionSeacrhModel();
        #endregion

        protected override async Task OnInitializedAsync()
        {
            actions = await _actionApiServices.GetAll();
        }

        async Task ActionSearch(EditContext context)
        {            
            actions = await _actionApiServices.Search(searchModel);
            StateHasChanged();
        }

        public void OnActionDelete(int deleteId , string name)
        {
            DeleteId = deleteId;
            ActionName = name;

            DeleteConfirmation.ConfirmationMessage = $"Are you sure to delete {name} ?!";
            DeleteConfirmation.Show();
        }

        public async Task OnConfirmDeleteAction(bool deleteConfirm)
        {
            if (deleteConfirm)
            {
                await _actionApiServices.Delete(DeleteId);
                _toastService.ShowSuccess("Xóa bản ghi thành công !", "Success");
                actions = await _actionApiServices.GetAll();
            }
        }

        public void AddNew()
        {
            _navigationManager.NavigateTo("/action-create");
        }
    }
}
