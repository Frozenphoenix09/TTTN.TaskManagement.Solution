using Microsoft.AspNetCore.Components;
using TTTN.TaskManagement.Models.Models.ActionModels;
using TTTN.TaskManagement.WebApp.Service;

namespace TTTN.TaskManagement.WebApp.Pages.Action
{
    public partial class Action
    {
        [Inject] 
        private IActionApiServices _actionApiServices { get; set; }
        private List<ActionViewModel> actions;
        protected override async Task OnInitializedAsync()
        {
            actions = await _actionApiServices.GetAll();
        }
    }
}
