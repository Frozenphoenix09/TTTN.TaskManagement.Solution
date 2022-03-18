using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TTTN.TaskManagement.Models.Models.ActionModels;
using TTTN.TaskManagement.WebApp.Service;

namespace TTTN.TaskManagement.WebApp.Pages.Action
{
    public partial class Action
    {
        [Inject] 
        private IActionApiServices _actionApiServices { get; set; }

        private List<ActionViewModel> actions;

        private ActionSeacrhModel searchModel = new ActionSeacrhModel();
        protected override async Task OnInitializedAsync()
        {
            actions = await _actionApiServices.GetAll();
        }
        async Task  ActionSearch(EditContext context)
        {            
            actions = await _actionApiServices.Search(searchModel);
            StateHasChanged();
        }
    }
}
