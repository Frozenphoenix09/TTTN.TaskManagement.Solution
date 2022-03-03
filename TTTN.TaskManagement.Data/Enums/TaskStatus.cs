using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTN.TaskManagement.Data.Enums
{
    public enum TaskStatus : int
    {
        Inprogress = 0,
        Pending = 1,
        Complete = 2,
        Canceled = 3,
        Close = 4
    }
}
