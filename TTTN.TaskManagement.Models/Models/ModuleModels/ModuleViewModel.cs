using System.ComponentModel.DataAnnotations;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.Data.SeedWork;

namespace TTTN.TaskManagement.Models.Models.ModuleModels
{
    public class ModuleViewModel
    {
        public int ModuleId { get; set; }

        [Required(ErrorMessage = " Tên không được bỏ trống !")]
        [MaxLength(255)]
        public string ModuleName { get; set; }

        public ICollection<ModuleAction>? ModuleActions { get; set; }
    }
    public class ModuleSearchModel : PagingParameters
    {
        public string? TextSearch { get; set; }
    }
}