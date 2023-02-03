using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
    public enum BasketballPosition
    {
        [Description("None")]
        None = 0,

        [Description("Guard")]
        Guard = 1,

        [Description("Forward")]
        Forward = 2,

        [Description("Center")]// I put these because i saw them
        Center = 3
    }
}
