using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTN.TaskManagement.Models.Models.ApiResultModels
{
    public class ApiResultModel
    {
        public bool? StatusCode { get; set; }
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
    }
}
