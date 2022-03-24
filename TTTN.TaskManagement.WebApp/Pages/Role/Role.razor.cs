using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TTTN.TaskManagement.Models.Models.RoleModels;
using TTTN.TaskManagement.WebApp.Components;
using TTTN.TaskManagement.WebApp.Service;
namespace TTTN.TaskManagement.WebApp.Pages.Role
{
    public partial class Role
    {
        #region InjectServices

        [Inject]
        private IRoleApiServices _roleApiServices { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Inject]
        IToastService _toastService { get; set; }
        #endregion
        #region Properties
        protected Confirmation DeleteConfirmation { get; set; }

        private int DeleteId { get; set; }
        private string RoleName { get; set; }
        #endregion
        #region Variables
        private List<RoleViewModel> roles;
        private RoleSearchModel searchModel = new RoleSearchModel();
        #endregion

        protected override async Task OnInitializedAsync()
        {
            roles = await _roleApiServices.GetAll();
        }

        async Task RoleSearch(EditContext context)
        {
            roles = await _roleApiServices.Search(searchModel);
            StateHasChanged();
        }

        public void OnRoleDelete(int deleteId, string name)
        {
            DeleteId = deleteId;
            RoleName = name;

            DeleteConfirmation.ConfirmationMessage = $"Are you sure to delete {name} ?!";
            DeleteConfirmation.Show();
        }

        public async Task OnConfirmDeleteRole(bool deleteConfirm)
        {
            if (deleteConfirm)
            {
                var result = await _roleApiServices.Delete(DeleteId);
                _toastService.ShowSuccess(result.Data["Message"].ToString(), "Success");
                roles = await _roleApiServices.GetAll();
            }
        }
        public void AddNew()
        {
            _navigationManager.NavigateTo("/role-create");
        }
    }
}
