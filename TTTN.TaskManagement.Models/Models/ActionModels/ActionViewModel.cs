using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTTN.TaskManagement.Data.Entities;

namespace TTTN.TaskManagement.Models.Models.ActionModels
{
    public  class ActionViewModel
    {
        public int ActionId { get; set; }
        [Required(ErrorMessage = "Action name is required !")]
        [MaxLength(255)]
        public string ActionName { get; set; }
        public ICollection<ModuleAction> ModuleActions { get; set; }
    }
}
