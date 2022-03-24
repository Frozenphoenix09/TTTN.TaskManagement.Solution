using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TTTN.TaskManagement.Data.SeedWork;
using TTTN.TaskManagement.Models.Models.ModuleModels;
using TTTN.TaskManagement.WebApp.Components;
using TTTN.TaskManagement.WebApp.Service;
namespace TTTN.TaskManagement.WebApp.Pages.Module
{
    public partial class Module
    {
        #region InjectServices

        [Inject]
        private IModuleApiServices _moduleApiServices { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Inject]
        IToastService _toastService { get; set; }
        #endregion
        #region Properties
        protected Confirmation DeleteConfirmation { get; set; }
        MetaData MetaData { get; set; } = new MetaData();

        private int DeleteId { get; set; }
        private string ModuleName { get; set; }
        #endregion
        #region Variables
        private List<ModuleViewModel> modules;
        private ModuleSearchModel searchModel = new ModuleSearchModel();
        #endregion

        protected override async Task OnInitializedAsync()
        {
            await GetModule();
        }

        async Task ModuleSearch(EditContext context)
        {
            await GetModule();
            StateHasChanged();
        }

        public void OnModuleDelete(int deleteId, string name)
        {
            DeleteId = deleteId;
            ModuleName = name;

            DeleteConfirmation.ConfirmationMessage = $"Are you sure to delete {name} ?!";
            DeleteConfirmation.Show();
        }

        public async Task OnConfirmDeleteModule(bool deleteConfirm)
        {
            if (deleteConfirm)
            {
                var result = await _moduleApiServices.Delete(DeleteId);
                _toastService.ShowSuccess(result.Data["Message"].ToString(), "Success");
                await GetModule();
            }
        }
        public void AddNew()
        {
            _navigationManager.NavigateTo("/module-create");
        }
        private async Task GetModule()
        {
            var pagingRespond = await _moduleApiServices.Search(searchModel);
            modules = pagingRespond.Items;
            MetaData = pagingRespond.MetaData;

        }

        private async Task SelectedPage(int page)
        {
            searchModel.CurrentPage = page;
            await GetModule();
        }
    }
}
