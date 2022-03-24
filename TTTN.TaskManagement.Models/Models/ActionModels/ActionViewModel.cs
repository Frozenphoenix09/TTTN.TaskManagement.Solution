using System.ComponentModel.DataAnnotations;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.SeedWork;

namespace TTTN.TaskManagement.Models.Models.ActionModels
{
    public class ActionViewModel
    {
        public int ActionId { get; set; }

        [Required(ErrorMessage = "Action name is required !")]
        [MaxLength(255)]
        public string ActionName { get; set; }

        public ICollection<ModuleAction>? ModuleActions { get; set; }
    }

    public class ActionSearchModel : PagingParameters
    {
        public string? TextSearch { get; set; }
    }
}