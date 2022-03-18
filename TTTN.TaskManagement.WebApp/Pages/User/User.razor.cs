using Microsoft.AspNetCore.Components;
using TTTN.TaskManagement.Models.Models.UserModels;
using TTTN.TaskManagement.WebApp.Service;

namespace TTTN.TaskManagement.WebApp.Pages.User
{
    public partial class User
    {
        [Inject]
        private IUserApiServices _userApiServices { get; set; }
        private List<UserViewModel> users;
        protected override async Task OnInitializedAsync()
        {
            users = await _userApiServices.GetAll();
        }
    }
}
