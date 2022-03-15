using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TTTN.TaskManagement.Data.Enums;

namespace TTTN.TaskManagement.Data.Entities
{
    public class Command
    {
        [Key]
        public int CommandId { get; set; }
        [Required (ErrorMessage ="Nội dung không được để trống ! ")]
        [MaxLength(int.MaxValue)]
        public string? CommandText { get; set; }
        public DateTime? CreatedDate { get; set; }
        [ForeignKey("Creator")]
        public int? CreatedBy { get; set; }
        public CommandStatus? Status { get; set; }
        public virtual User? Creator { get; set; }
    }
}
