using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TTTN.TaskManagement.Data.SeedWork;
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
        private ActionSearchModel searchModel = new ActionSearchModel();
        MetaData MetaData { get; set; } = new MetaData();
        #endregion

        protected override async Task OnInitializedAsync()
        {
             await GetAction();
        }

        async Task ActionSearch(EditContext context)
        {
            await GetAction();
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
                var  result = await _actionApiServices.Delete(DeleteId);
                _toastService.ShowSuccess(result.Data["Message"].ToString(), "Success");
                await GetAction();
            }
        }
        private async Task GetAction()
        {
            var pagingRespond = await _actionApiServices.Search(searchModel);
            actions = pagingRespond.Items;
            MetaData = pagingRespond.MetaData;
            
        }

        public void AddNew()
        {
            _navigationManager.NavigateTo("/action-create");
        }
        private async Task SelectedPage(int page)
        {
            searchModel.CurrentPage = page;
            await GetAction();
        }
    }
}
