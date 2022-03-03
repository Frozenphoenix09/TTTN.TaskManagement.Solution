using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTTN.TaskManagement.Data.Enums
{
    public enum CommandStatus : int 
    {
        New = 0,
        OnTask = 1,
        Cancled = 2,
        Done = 3
    }
}
