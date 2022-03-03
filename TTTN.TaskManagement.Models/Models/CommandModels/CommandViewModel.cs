using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTN.TaskManagement.Models.Models.CommandModels
{
    public class CommandViewModel
    {
        public int CommandId { get; set; }
        [Required(ErrorMessage = "Nội dung nhiệm vụ không được để trống !")]
        [MaxLength(int.MaxValue)]
        public string CommandText { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? Status { get; set; }
        public string Creator { get; set; }
    }
}
