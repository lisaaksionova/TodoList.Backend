using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist.DAL.Enums
{
    public enum TaskStatus
    {
        [Description("Pending")]
        Pending,
        [Description("InProgress")]
        InProgress,
        [Description("Done")]
        Done
    }
}
