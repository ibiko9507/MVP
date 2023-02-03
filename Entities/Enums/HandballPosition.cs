using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
    public enum HandballPosition
    {
        [Description("Non")]
        None = 0,

        [Description("Goal Keeper")]
        GoalKeeper = 1,

        [Description("Field Player")]
        FieldPlayer = 2
    }
}
